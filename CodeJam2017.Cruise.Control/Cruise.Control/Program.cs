using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace Cruise.Control
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");

            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";

            StringBuilder sb = new StringBuilder();
            int caseCounter = 1;
            for (int i = 1; i < lines.Length; i++)
            {
                double d = double.Parse(lines[i].Split(new char[] { ' ' })[0]);
                double n = double.Parse(lines[i].Split(new char[] { ' ' })[1]);

                double fullTimeRequired = 0;
                for (int j = 0; j < n; j++)
                {
                    i++;
                    double k = double.Parse(lines[i].Split(new char[] { ' ' })[0]);
                    double s = double.Parse(lines[i].Split(new char[] { ' ' })[1]);
                    
                    double timeRequired = (d - k) / s;

                    if (timeRequired > fullTimeRequired)
                        fullTimeRequired = timeRequired;
                }

                sb.AppendLine($"Case #{caseCounter}: {Math.Round(d / fullTimeRequired, 6).ToString("F6", nfi)}");
                caseCounter++;
            }

            File.WriteAllText("output.txt", sb.ToString());
        }
    }
}