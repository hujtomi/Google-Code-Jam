using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam2016.RevengeOfThePancakes
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

            for (int i = 1; i < lines.Length; i++)
            {
                int flipCounter = 0;
                string line = lines[i].Trim();

                char[] letters = line.ToCharArray();
                bool[] pencakeStack = new bool[letters.Length];

                for (int j = 0; j < letters.Length; j++)
                {
                    pencakeStack[j] = letters[j] == '+';
                }

                for (int j = 0; j < letters.Length; j++)
                {
                    if(!pencakeStack[letters.Length - 1 - j])
                    {
                        flipCounter++;

                        for (int k = 0; k < letters.Length - 1 - j; k++)
                        {
                            pencakeStack[k] = !pencakeStack[k];
                        }
                    }
                }

                result.AppendLine($"Case #{i}: {flipCounter}");
            }

            Console.WriteLine(result);
            File.WriteAllText("output.txt", result.ToString());
        }
    }
}
