using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam2014.DeceitfulWar
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
                int blockNumber = int.Parse(lines[1 + i * 3]);

                string[] NaomisStrArr = lines[2 + i * 3].Split(' ');
                string[] KensStrArr = lines[3 + i * 3].Split(' ');

                List<double> Naomis = new List<double>();
                List<double> Kens = new List<double>();

                foreach (var item in NaomisStrArr)
                {
                    Naomis.Add(double.Parse(item, CultureInfo.InvariantCulture));
                }

                foreach (var item in KensStrArr)
                {
                    Kens.Add(double.Parse(item, CultureInfo.InvariantCulture));
                }

                Naomis.Sort();
                Kens.Sort();

                int counter = 0;
                for (int j = Naomis.Count - 1; j >= 0; j--)
			    {
                    if (Naomis.ElementAt(j) > Kens.Last())
                    {
                        counter++;
                        Kens.Remove(Kens.First());
                    }
                    else {
                        foreach (var item in Kens)
                        {
                            if (item > Naomis.ElementAt(j)) {
                                Kens.Remove(item);
                                break;
                            }
                        }
                    }
			    }

                Kens.Clear();

                foreach (var item in KensStrArr)
                {
                    Kens.Add(double.Parse(item, CultureInfo.InvariantCulture));
                }

                Kens.Sort();

                int maxDeceitfulCounter = 0;

                while (Naomis.Count() > 0)
                {

                    int deceitfulCounter = 0;
                    for (int j = Naomis.Count - 1; j >= 0; j--)
                    {
                        if (Naomis.ElementAt(j) > Kens.ElementAt(j))
                        {
                            deceitfulCounter++;
                        }
                    }

                    if (deceitfulCounter > maxDeceitfulCounter)
                        maxDeceitfulCounter = deceitfulCounter;

                    Naomis.Remove(Naomis.First());
                    Kens.Remove(Kens.Last());
                }

                sb.AppendLine(string.Format("Case #{0}: {1} {2}", i + 1, maxDeceitfulCounter, counter));
            }

            //Console.WriteLine(sb.ToString());

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\..\solution.out"))
            {
                file.Write(sb.ToString());
            }
        }
    }
}
