using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeakSalt.Extensions;

namespace WeakSalt
{
    class Program
    {
        static async Task Main(string[] args)
        {
            File.Create("result.txt").Close();
            var input = await File.ReadAllLinesAsync("text.txt");
            var guessWord = Encoding.UTF8.GetBytes("And thus the native hue of resolution");
            var inputBytes = new List<IEnumerable<byte>>();

            foreach (var line in input)
            {
                inputBytes.Add(line.FromHex().Select(Convert.ToByte));
            }
            

            for (var i = 0; i < inputBytes.Count; i++)
            {
                for (var j = 0; j < inputBytes.Count; j++)
                {
                    var res = inputBytes[i].Xor(inputBytes[j]);
                    var xoredGuessWord = Encoding.UTF8.GetString(res.Xor(guessWord).ToArray());
                    await File.AppendAllTextAsync("result.txt", $"XOR: {i + 1} with {j + 1}" + Environment.NewLine);
                    await File.AppendAllTextAsync("result.txt", xoredGuessWord + Environment.NewLine);
                    await File.AppendAllTextAsync("result.txt", "==================================" + Environment.NewLine);

                }
            }
        }
    }
}