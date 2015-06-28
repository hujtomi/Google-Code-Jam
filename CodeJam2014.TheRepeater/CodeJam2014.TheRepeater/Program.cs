using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam2014.TheRepeater
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            StringBuilder sb = new StringBuilder();

            string[] lines = System.IO.File.ReadAllLines(@"..\..\input.in");

            int caseCount = int.Parse(lines[0]);

            int caseFirstLine = 1;

            for (int t = 0; t < caseCount; t++)
            {
                int numberOfString = int.Parse(lines[caseFirstLine]);
                bool feglaWon = false;

                int maxDiff = -1;
                for (int i = 1; i < numberOfString; i++)
                {
                    string first = lines[caseFirstLine + i];
                    string next = lines[caseFirstLine + i + 1];

                    int diff = diffCount(first, next);

                    if (diff == -1)
                    {
                        sb.AppendLine(string.Format("Case #{0}: {1}", t + 1, "Fegla Won"));
                        feglaWon = true;
                        break;
                    }
                    else
                    {
                        if (diff > maxDiff)
                        {
                            maxDiff = diff;
                        }
                    }
                }

                if (!feglaWon)
                {
                    sb.AppendLine(string.Format("Case #{0}: {1}", t + 1, maxDiff));
                }

                caseFirstLine += 1 + numberOfString;
            }

            Console.WriteLine(sb.ToString());
            System.IO.File.WriteAllText(@"..\..\output.out", sb.ToString());

        }

        public int diffCount(string first, string next)
        {
            int diff = 0;

            if (first[0] != next[0])
                return -1;

            while (first.Length != 0 && next.Length != 0)
            {
                char current = first[0];

                int firstCounter = 0;
                int nextCounter = 0;

                while (first.Length > 0 && first[0] == current)
                {
                    first = first.Substring(1);
                    firstCounter++;
                }
                while (next.Length > 0 && next[0] == current)
                {
                    next = next.Substring(1);
                    nextCounter++;
                }

                diff += Math.Abs(firstCounter - nextCounter);

                if (first.Length == 0 && next.Length == 0)
                    return diff;
            }

            return -1;
        }
    }
}
