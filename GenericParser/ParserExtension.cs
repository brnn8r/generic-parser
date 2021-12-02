using System;
using System.ComponentModel;

namespace GenericParser
{
    public static class ParserExtension
    {

        public static T ConvertTo<T>(this T t, T defaultValue = default)
        {
            return t;
        }

        public static T ConvertTo<T>(this object o, T defaultValue = default)
        {
            if (o is T t) return t;

            try
            {
                return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(o);
            }
            catch (ArgumentException)
            {
                return defaultValue;
            }            
            catch (NotSupportedException)
            {
                return defaultValue;
            }
        }
    }
}
