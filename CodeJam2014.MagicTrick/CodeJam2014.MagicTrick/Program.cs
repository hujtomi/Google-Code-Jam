using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam2014.MagicTrick
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
            string[] lines = System.IO.File.ReadAllLines(@"..\..\first.in");

            int cases = int.Parse(lines[0]);

            for (int i = 0; i < cases; i++)
            {
                int firstAnsware = int.Parse( lines[1 + i * 10] );

                string[] firstRow = lines[1 + i * 10 + firstAnsware].Split(' ');

                int secoundAnsware = int.Parse(lines[1 + 5 + i * 10]);

                string[] secoundRow = lines[1 + 5 + i * 10 + secoundAnsware].Split(' ');

                int solutionCounter = 0;
                string solution = string.Empty;
                foreach (var first in firstRow)
                {
                    foreach (var secound in secoundRow)
                    {
                        if (first == secound) {
                            solution = first;
                            solutionCounter++;
                        }
                    }
                }

                if (solutionCounter == 0)
                {
                    sb.AppendLine(string.Format("Case #{0}: {1}", i + 1, "Volunteer cheated!"));
                }
                else if (solutionCounter > 1)
                {
                    sb.AppendLine(string.Format("Case #{0}: {1}", i + 1, "Bad magician!"));
                }
                else {
                    sb.AppendLine(string.Format("Case #{0}: {1}", i + 1, solution));
                }
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\..\solution.out"))
            {
                file.Write(sb.ToString());
            }
        }
    }
}
