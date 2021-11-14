using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;

namespace WeakSalt.Extensions
{
    public static class StringExtensions
    {
        public static string ToHex(this string str)
        {
            return str.Select(x => Convert.ToString(x, 16)).Aggregate("", (s, s1) => s + s1);
        }

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

        public static string XorHexStrings(this string str1, string str2)
        {
            var val1 = BigInteger.Parse(str1, NumberStyles.HexNumber);
            var val2 = BigInteger.Parse(str2, NumberStyles.HexNumber);
            var result = val1 ^ val2;
            var resultString = result.ToString("X");
            return resultString.Length % 2 == 0 ? resultString : resultString + "0";
        }

        public static IEnumerable<byte> HexToByteEnumerable(this string str)
        {
            var result = new List<byte>();
          
            for (var i = 0; i < str.Length; i += 2)
            {
                var hexStr = str.Substring(i, 2);
                result.Add(Convert.ToByte(hexStr, 16));
            }

            return result;
        }
    }
}