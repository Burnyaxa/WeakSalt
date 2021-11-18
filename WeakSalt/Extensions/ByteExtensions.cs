using System.Collections.Generic;
using System.Linq;

namespace WeakSalt.Extensions
{
    public static class ByteExtensions
    {
        public static IEnumerable<byte> Xor(this IEnumerable<byte> first, IEnumerable<byte> second)
        {
            var firstLength = first.Count();
            var secondLength = second.Count();
            var result = new List<byte>();

            for (int i = 0; i < firstLength; i++)
            {
                result.Add((byte)(first.ElementAt(i) ^ second.ElementAt(i % secondLength)));
            }

            return result;
        }
    }
}