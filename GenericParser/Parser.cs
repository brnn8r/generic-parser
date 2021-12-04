using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericParser
{
    public static class Parser
    {
        public static T Parse<T>(T t)
        {
            return t;
        }

        public static T Parse<T>(T t, T defaultValue)
        {
            return t;
        }

        public static T Parse<T>(object o)
        {
            return o.ConvertTo<T>();
        }

        public static T Parse<T>(object o, T defaultValue)
        {
            return o.ConvertTo(defaultValue);
        }
    }
}
