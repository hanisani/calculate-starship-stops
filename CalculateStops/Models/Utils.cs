using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CalculateStops.Models
{
    public class Utils
    {
        public static object GetEnumValue(Enum enumValue)
        {
            object output = null;
            Type type = enumValue.GetType();
            FieldInfo fi = type.GetField(enumValue.ToString());
            if (fi.GetCustomAttributes(typeof(Value), false) is Value[] attrs)
                if (attrs.Length > 0)
                    output = attrs[0].GetValue;
                else
                    output = int.Parse(enumValue.ToString("D"));

            return output;
        }      
        public static List<ListEnum> GetListEnum(Type value)
        {
            List<ListEnum> retorno = new List<ListEnum>();

            foreach (string campoEnum in Enum.GetNames(value))
            {
                object objValue = GetEnumValue((Enum)Enum.Parse(value, campoEnum));
                FieldInfo fi = value.GetField(campoEnum);
                string strStringValue = string.Empty, strStringDescription = string.Empty;

                if (fi.GetCustomAttributes(typeof(StringValueAttribute), false) is StringValueAttribute[] attribs && attribs.Length > 0)
                    strStringValue = attribs[0].StringValue;

                if (fi.GetCustomAttributes(typeof(StringDescriptionAttribute), false) is StringDescriptionAttribute[] attr && attr.Length > 0)
                    strStringDescription = attr[0].StringDescription;

                retorno.Add(new ListEnum
                {
                    Name = fi.Name,
                    StringValue = strStringValue,
                    Value = objValue.ToString(),
                    StringDescription = strStringDescription
                });
            }

            return retorno.OrderBy(entry => entry.Name).ToList();
        }
        public static string GetStringValue(Enum value)
        {
            string output = null;
            Type type = value.GetType();
            FieldInfo fi = type.GetField(value.ToString());
            StringValueAttribute[] attrs = fi.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
            if (attrs.Length > 0)
                output = attrs[0].StringValue;
            return output;
        }
    }
    public class Value : Attribute
    {
        private string _value;
        public Value(string value)
        {
            _value = value;
        }
        public string GetValue
        {
            get { return _value; }
        }
    }
}