//
//
// GtkHtmlHtmlRender.cs: Implementation of IHtmlRender that uses Gtk.HTML
//
// Author: Mario Sopena
//
using System;
using Gtk;
using System.IO;

namespace Monodoc {
class GtkHtmlHtmlRender : IHtmlRender {
	
	HTML html_panel;
	public Widget HtmlPanel {
		get { return (Widget) html_panel; }
	}

	string url;
	public string Url {
		get { return url; }
	}

	Browser browser;
	public event EventHandler OnUrl;
	public event EventHandler UrlClicked;

	
	public GtkHtmlHtmlRender (Browser browser) 
	{
		html_panel = new HTML();
		html_panel.Show(); 
		html_panel.LinkClicked += new LinkClickedHandler (LinkClicked);
		html_panel.OnUrl += new OnUrlHandler (OnUrlMouseOver);
		html_panel.UrlRequested += new UrlRequestedHandler (UrlRequested);
		this.browser = browser;
	}
	
	protected void LinkClicked (object o, LinkClickedArgs args)
	{
		url = args.Url;
		if (UrlClicked != null)
			UrlClicked (this, new EventArgs());
	}
	
	protected void OnUrlMouseOver (object o, OnUrlArgs args)
	{
		url = args.Url;
		if (OnUrl != null)
			OnUrl (this, args);
	}

	public void JumpToAnchor (string anchor)
	{
		html_panel.JumpToAnchor(anchor);
	}

	public void Copy () 
	{
		html_panel.Copy();	
	}

	public void SelectAll () 
	{
		html_panel.SelectAll();	
	}

	public void Render (string html_code) 
	{
		Gtk.HTMLStream stream = html_panel.Begin ("text/html");
		stream.Write(html_code);
		html_panel.End (stream, HTMLStreamStatus.Ok);
	}

	protected void UrlRequested (object sender, UrlRequestedArgs args)
	{
		Stream s = browser.help_tree.GetImage (args.Url);
		
		if (s == null)
			s = browser.GetResourceImage ("monodoc.png");
		byte [] buffer = new byte [8192];
		int n, m;
		m=0;
		while ((n = s.Read (buffer, 0, 8192)) != 0) {
			args.Handle.Write (buffer, n);
			m += n;
		}
		args.Handle.Close (HTMLStreamStatus.Ok);
	}
	
}
}
