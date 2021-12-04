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

            if (o == null) return defaultValue;

            try
            {
                return (T)Convert.ChangeType(o, typeof(T));

            }
            catch (Exception)
            {
                try
                {
                    return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(o);
                }
                catch (Exception)
                {
                    return defaultValue;
                }
            }
        }
    }
}
