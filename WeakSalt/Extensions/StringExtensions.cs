using System;
using System.Text;

namespace WeakSalt.Extensions
{
    public static class StringExtensions
    {
        public static string FromHex(this string str)
        {
            var result = new StringBuilder();
            var bufferBuilder = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                bufferBuilder.Append(str[i]);
                if (bufferBuilder.Length == 2)
                {
                    result.Append((char)Convert.ToByte(bufferBuilder.ToString(), 16));
                    bufferBuilder.Clear();
                }
            }

            return result.ToString();
        }
    }
}