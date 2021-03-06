// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 1.1.4322.2032
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

// 
// This source code was auto-generated by Mono Web Services Description Language Utility
//


/// <remarks/>
/// <remarks>
///Web service for the MonoDoc contribution system
///</remarks>
[System.Web.Services.WebServiceBinding(Name="ContributionsSoap", Namespace="http://tempuri.org/")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public class Contributions : System.Web.Services.Protocols.SoapHttpClientProtocol {
    
    public Contributions() {
        this.Url = "http://www.go-mono.com/docs/server.asmx";
    }
    
    /// <remarks>
///Check the client/server version;  0 means that the server can consume your data
///</remarks>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CheckVersion", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped, Use=System.Web.Services.Description.SoapBindingUse.Literal)]
    public int CheckVersion(int version) {
        object[] results = this.Invoke("CheckVersion", new object[] {
            version});
        return ((int)(results[0]));
    }
    
    public System.IAsyncResult BeginCheckVersion(int version, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("CheckVersion", new object[] {
            version}, callback, asyncState);
    }
    
    public int EndCheckVersion(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((int)(results[0]));
    }
    
    /// <remarks>
///Requests a registration for a login
///</remarks>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Register", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped, Use=System.Web.Services.Description.SoapBindingUse.Literal)]
    public int Register(string login) {
        object[] results = this.Invoke("Register", new object[] {
            login});
        return ((int)(results[0]));
    }
    
    public System.IAsyncResult BeginRegister(string login, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("Register", new object[] {
            login}, callback, asyncState);
    }
    
    public int EndRegister(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((int)(results[0]));
    }
    
    /// <remarks>
///Returns the latest serial number used for a change on the server
///</remarks>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetSerial", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped, Use=System.Web.Services.Description.SoapBindingUse.Literal)]
    public int GetSerial(string login, string password) {
        object[] results = this.Invoke("GetSerial", new object[] {
            login,
            password});
        return ((int)(results[0]));
    }
    
    public System.IAsyncResult BeginGetSerial(string login, string password, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetSerial", new object[] {
            login,
            password}, callback, asyncState);
    }
    
    public int EndGetSerial(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((int)(results[0]));
    }
    
    /// <remarks>
///Submits a GlobalChangeSet as a contribution
///</remarks>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Submit", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped, Use=System.Web.Services.Description.SoapBindingUse.Literal)]
    public int Submit(string login, string password, System.Xml.XmlNode node) {
        object[] results = this.Invoke("Submit", new object[] {
            login,
            password,
            node});
        return ((int)(results[0]));
    }
    
    public System.IAsyncResult BeginSubmit(string login, string password, System.Xml.XmlNode node, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("Submit", new object[] {
            login,
            password,
            node}, callback, asyncState);
    }
    
    public int EndSubmit(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((int)(results[0]));
    }
    
    /// <remarks>
///Obtains the list of pending contributions
///</remarks>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetPendingChanges", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped, Use=System.Web.Services.Description.SoapBindingUse.Literal)]
    public PendingChange[] GetPendingChanges(string login, string password) {
        object[] results = this.Invoke("GetPendingChanges", new object[] {
            login,
            password});
        return ((PendingChange[])(results[0]));
    }
    
    public System.IAsyncResult BeginGetPendingChanges(string login, string password, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetPendingChanges", new object[] {
            login,
            password}, callback, asyncState);
    }
    
    public PendingChange[] EndGetPendingChanges(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((PendingChange[])(results[0]));
    }
    
    /// <remarks>
///Obtains a change set for a user
///</remarks>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/FetchContribution", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped, Use=System.Web.Services.Description.SoapBindingUse.Literal)]
    public System.Xml.XmlNode FetchContribution(string login, string password, int person_id, int serial) {
        object[] results = this.Invoke("FetchContribution", new object[] {
            login,
            password,
            person_id,
            serial});
        return ((System.Xml.XmlNode)(results[0]));
    }
    
    public System.IAsyncResult BeginFetchContribution(string login, string password, int person_id, int serial, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("FetchContribution", new object[] {
            login,
            password,
            person_id,
            serial}, callback, asyncState);
    }
    
    public System.Xml.XmlNode EndFetchContribution(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((System.Xml.XmlNode)(results[0]));
    }
    
    /// <remarks>
///ADMIN: Obtains the number of pending commits
///</remarks>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetStatus", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped, Use=System.Web.Services.Description.SoapBindingUse.Literal)]
    public Status GetStatus(string login, string password) {
        object[] results = this.Invoke("GetStatus", new object[] {
            login,
            password});
        return ((Status)(results[0]));
    }
    
    public System.IAsyncResult BeginGetStatus(string login, string password, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetStatus", new object[] {
            login,
            password}, callback, asyncState);
    }
    
    public Status EndGetStatus(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((Status)(results[0]));
    }
    
    /// <remarks>
///ADMIN: Updates the status of a contribution
///</remarks>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/UpdateStatus", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped, Use=System.Web.Services.Description.SoapBindingUse.Literal)]
    public void UpdateStatus(string login, string password, int person_id, int contrib_id, int status) {
        this.Invoke("UpdateStatus", new object[] {
            login,
            password,
            person_id,
            contrib_id,
            status});
    }
    
    public System.IAsyncResult BeginUpdateStatus(string login, string password, int person_id, int contrib_id, int status, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("UpdateStatus", new object[] {
            login,
            password,
            person_id,
            contrib_id,
            status}, callback, asyncState);
    }
    
    public void EndUpdateStatus(System.IAsyncResult asyncResult) {
        this.EndInvoke(asyncResult);
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
public class PendingChange {
    
    /// <remarks/>
    public string Login;
    
    /// <remarks/>
    public int ID;
    
    /// <remarks/>
    public int Serial;
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
public class Status {
    
    /// <remarks/>
    public int Contributions;
    
    /// <remarks/>
    public int Commited;
    
    /// <remarks/>
    public int Pending;
}
