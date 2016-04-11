using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam2016.CountingSheep
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            StringBuilder result = new StringBuilder();
            var lines = File.ReadAllLines("input.txt");

            bool[] digits = new bool[10];

            for (int i = 1; i < lines.Length; i++)
            {
                for (int j = 0; j < digits.Length; j++)
                {
                    digits[j] = false;
                }

                if (long.Parse(lines[i]) == 0)
                {
                    result.AppendLine($"Case #{i}: INSOMNIA");
                    continue;
                }
                
                int multiplier = 1;
                do
                {
                    long number = long.Parse(lines[i]) * multiplier;
                    multiplier++;

                    char[] letters = number.ToString().ToCharArray();
                    foreach (var letter in letters)
                    {
                        digits[int.Parse(letter.ToString())] = true;
                    }

                    if(digits.All(d => d))
                    {
                        result.AppendLine($"Case #{i}: {number}");
                        break;
                    }                    
                } while (true);                
            }

            Console.WriteLine(result);
            File.WriteAllText("output.txt", result.ToString());
        }
    }
}
