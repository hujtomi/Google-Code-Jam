using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam2014.CookieClickerAlpha
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

            int cases = int.Parse(lines[0]);

            for (int i = 0; i < cases; i++)
            {
                double cookiePerSec = 2;
                
                string[] values = lines[i + 1].Split(' ');

                double C = double.Parse(values[0], CultureInfo.InvariantCulture);
                double F = double.Parse(values[1], CultureInfo.InvariantCulture);
                double X = double.Parse(values[2], CultureInfo.InvariantCulture);

                double totalTime = X / cookiePerSec;
                //double totalTimeWith1Farm = C / cookiePerSec + X / (cookiePerSec + F);
                //double totalTimeWith2Farm = C / cookiePerSec + C / (cookiePerSec + F) + X / (cookiePerSec + 2 * F);

                int f = 1;

                double newTotalTime = 0;

                do
                {
                    if (newTotalTime != 0 && newTotalTime < totalTime) {
                        totalTime = newTotalTime;
                    }

                    newTotalTime = 0;

                    for (int k = 0; k < f; k++)
			        {
			            newTotalTime += C / (k * F + cookiePerSec); 
			        }

                    newTotalTime += X / (cookiePerSec + f * F);
                    f++;
                }
                while (newTotalTime < totalTime);

                sb.AppendLine(string.Format("Case #{0}: {1}", i + 1, totalTime.ToString("F7").Replace(',', '.')));

            }

            //Console.WriteLine(sb.ToString());

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\..\solution.out"))
            {
                file.Write(sb.ToString());
            }
        }
    }
}
