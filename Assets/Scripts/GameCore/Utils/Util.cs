using System;

namespace GameCore.Utils
{
    public static class Util
    {
        public static T EnsureNotNull<T>(this T? value, string? message = null)
        {
            if (value == null)
            {
                throw new Exception(message ?? typeof(T).FullName);
            }

            return value;
        }
    }
}