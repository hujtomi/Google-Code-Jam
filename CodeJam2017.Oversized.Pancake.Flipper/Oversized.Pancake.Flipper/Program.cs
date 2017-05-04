using System;
using System.IO;
using System.Text;
using System.Linq;

namespace Oversized.Pancake.Flipper
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i < lines.Length; i++)
            {
                string patternString = lines[i].Split(new char[] { ' ' })[0];
                int flipperSize = int.Parse(lines[i].Split(new char[] { ' ' })[1]);

                bool[] pattern = new bool[patternString.Length];

                var patternChars = patternString.ToCharArray();
                for (int j = 0; j < patternString.Length; j++)
                {
                    pattern[j] = patternChars[j] == '+';
                }

                int flipCount = 0;
                for (int j = 0; j <= pattern.Length - flipperSize; j++)
                {
                    if (!pattern[j])
                    {
                        flipCount++;
                        for (int k = 0; k < flipperSize; k++)
                        {
                            pattern[j + k] = !pattern[j + k];
                        }
                    }
                }

                if(pattern.Any(p => p == false))
                {
                    sb.AppendLine($"Case #{i}: IMPOSSIBLE");
                } else
                {
                    sb.AppendLine($"Case #{i}: {flipCount}");
                }
            }

            File.WriteAllText("output.txt", sb.ToString());
        }
    }
}