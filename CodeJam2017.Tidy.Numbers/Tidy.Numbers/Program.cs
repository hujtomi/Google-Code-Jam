using System;
using System.IO;
using System.Numerics;
using System.Text;

namespace Tidy.Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            StringBuilder output = new StringBuilder();

            for (int i = 1; i < input.Length; i++)
            {
                BigInteger value = BigInteger.Parse(input[i]);

                if(value.ToString().Length == 1)
                {
                    output.AppendLine($"Case #{i}: {value}");
                    continue;
                }

                var digits = value.ToString().ToCharArray();
                for (int j = 1; j < digits.Length; j++)
                {
                    if(digits[j-1] > digits[j])
                    {                        
                        var diff = BigInteger.Pow(new BigInteger(10), digits.Length - 1 - j);
                        value = BigInteger.Add(value, BigInteger.Multiply(diff, BigInteger.MinusOne));

                        if (digits[j] == '0')
                        {
                            digits = value.ToString().ToCharArray();
                            for (int k = j; k < digits.Length; k++)
                            {
                                digits[k] = '9';
                            }
                            value = BigInteger.Parse(new string(digits));
                        }
                        else
                            digits = value.ToString().ToCharArray();

                        j = 0;
                    }
                }

                output.AppendLine($"Case #{i}: {value}");
            }

            File.WriteAllText("output.txt", output.ToString());
        }
    }
}