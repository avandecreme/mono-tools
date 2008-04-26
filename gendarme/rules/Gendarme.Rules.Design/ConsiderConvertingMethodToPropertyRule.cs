//
// Gendarme.Rules.Design.ConsiderConvertingMethodToPropertyRule
//
// Authors:
//	Adrian Tsai <adrian_tsai@hotmail.com>
//	Sebastien Pouliot  <sebastien@ximian.com>
//
// Copyright (c) 2007 Adrian Tsai
// Copyright (C) 2008 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;

using Mono.Cecil;

using Gendarme.Framework;
using Gendarme.Framework.Rocks;

namespace Gendarme.Rules.Design {

	[Problem ("This method looks like a candidate to be a property.")]
	[Solution ("If possible change this method into a property, otherwise you can ignore the rule.")]
	public class ConsiderConvertingMethodToPropertyRule : Rule, IMethodRule {

		static readonly string [] whitelist = {	"GetEnumerator",
							"GetHashCode",
							"GetType",
							"GetTypeCode",
							"GetValue",
							"HasElementTypeImpl"};
		private const string Void = "System.Void";
		string [] parameter = new string [1];

		static bool StartsWith (string start, string name)
		{
			return name.StartsWith (start, true, null);
		}

		// report if there is a SetX (value) that match
		string ReportAssociatedSetter (MethodDefinition getter)
		{
			string name = "Set" + getter.Name.Substring (3);
			parameter [0] = getter.ReturnType.ReturnType.FullName;
			MethodDefinition setter = getter.DeclaringType.GetMethod (name, Void, parameter);
			return setter == null ? String.Empty : setter.ToString ();
		}

		public RuleResult CheckMethod (MethodDefinition method)
		{
			// rules do not apply to constructors, methods returning an array, properties
			if (method.IsConstructor || method.IsSpecialName ||
				method.ReturnType.ReturnType.IsArray () || method.IsProperty ())
				return RuleResult.DoesNotApply;

			// we don't apply the rule to overrides since the base method can be
			// outside the developer's control (and if not this is the *one* that
			// should be reported)
			if (method.IsVirtual && !method.IsNewSlot)
				return RuleResult.DoesNotApply;

			// rules do not apply to code generated by the compiler (e.g. anonymous methods)
			// or generated by a tool (e.g. web services)
			if (method.IsGeneratedCode ())
				return RuleResult.DoesNotApply;

			// ignore the some common Get* method names used in the framework
			foreach (string s in whitelist) {
				if (method.Name == s)
					return RuleResult.DoesNotApply;
			}

			// rule applies

			// If it starts with "get" or "is" or "has", has no parameters and returns something
			bool get = StartsWith ("get", method.Name);
			bool isp = StartsWith ("is", method.Name);
			bool has = StartsWith ("has", method.Name);
			if ((get || isp || has) && (method.Parameters.Count == 0) && (method.ReturnType.ReturnType.FullName != Void)) {
				// if it's a getter then look for a setter (to complete the report)
				string msg = get ? ReportAssociatedSetter (method) : String.Empty;
				Runner.Report (method, Severity.Low, Confidence.Normal, msg);
				return RuleResult.Failure;
			}

			return RuleResult.Success;
		}
	}
}
