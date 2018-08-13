using System;
using System.Diagnostics;

namespace CalculateStops.Models
{
    public class StringValueAttribute : Attribute
    {
        public string StringValue { get; protected set; }        
        public StringValueAttribute(string value)
        {
            this.StringValue = value;
        }
    }
    public class StringDescriptionAttribute : Attribute
    {
        public string StringDescription { get; protected set; }        
        public StringDescriptionAttribute(string value)
        {
            this.StringDescription = value;
        }
    }
}