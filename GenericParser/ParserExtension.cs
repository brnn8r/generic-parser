using System;
using System.ComponentModel;

namespace GenericParser
{
    public static class ParserExtension
    {

        public static T ConvertTo<T>(this T t)
        {
            return t;
        }

        public static T ConvertTo<T>(this T t, T defaultValue)
        {
            return t;
        }

        public static T ConvertTo<T>(this object o)
        {
            if (o is T t) return t;

            try
            {
                return (T)Convert.ChangeType(o, typeof(T));
            }
            catch (Exception)
            {
                return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(o);
            }
        }

        public static T ConvertTo<T>(this object o, T defaultValue)
        {
            if (o == null) return defaultValue;

            try
            {
                return o.ConvertTo<T>();
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
          
    }
}
