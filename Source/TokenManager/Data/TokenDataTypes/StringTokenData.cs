﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenManager.Data.Interfaces;

namespace TokenManager.Data.TokenDataTypes
{
	public class StringTokenData : ITokenData
	{
		/// <summary>
		/// Creates a field that gathers a sitecore item's ID from the user in the form of a Sitecore content tree
		/// </summary>
		/// <param name="label">The label displayed to the authors describing what the field is for</param>
		/// <param name="name">The key that's used when placing/retrieving information into the token definition</param>
		/// <param name="placeholder">The text that appears in light gray that is over the top of the input field guiding users suggested input</param>
		/// <param name="required">If true, the user will not be able to leave this field blank</param>
		/// <param name="defaultValue">The starting value of the token data</param>
		public StringTokenData(string label, string name, string placeholder, bool required, string defaultValue = "")
		{
			Name = name;
			Label = label;
			Data = new ExpandoObject();
			Data.Placeholder = placeholder;
			Required = required;
			DefaultValue = defaultValue;
		}
		public string Name { get; set; }
		public string Label { get; set; }
		public bool Required { get; set; }
		public string DefaultValue { get; set; }

		public string AngularMarkup => $@"
    <div class=""field-row {{{{field.class}}}}"">
        <span class=""field-label"">{{{{field.Label}}}} </span>
        <div ng-init=""token.data[field.Name]= token.data[field.Name] ? token.data[field.Name] : '{DefaultValue}';"" class=""field-data"">
			<textarea ng-model=""token.data[field.Name]"" rows=""4"" cols=""50"" placeholder=""{{{{field.Data.Placeholder}}}}"">
			</textarea>
        </div>
    </div>
";

		public dynamic Data { get; set; }
		public object GetValue(string value)
		{
			return value;
		}
	}
}
