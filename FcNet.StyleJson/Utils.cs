using System;

namespace FcNet.FormStyleJson
{
    public static class Utils
    {
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static int GetInt(string value)
        {
            int x;
            int.TryParse(value.Trim(), out x);
            return x;
        }

        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
