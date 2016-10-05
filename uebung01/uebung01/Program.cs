/*1510601027 fhs38532
  Thomas Siller
  -------------------
  1510601032 fhs38596
  Patrick Obermüller*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uebung01
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = "";
            double numberBase = 0;
            double baseTarget = 0;

            if(args.Length == 3)
            {
                number = args[0];
                if (
                    double.TryParse(args[1], out numberBase) && 
                    double.TryParse(args[2], out baseTarget) &&
                    validateParseNumberBase(number, numberBase)
                ) {
                    double numToBaseTen = convertNumToBaseTen(number, numberBase);
                    Console.WriteLine("Result: " + convertNumToBase((int)numToBaseTen, baseTarget));
                } else
                {
                    Console.WriteLine("Couldn't Parse Arguments");
                }
            } else
            {
                Console.WriteLine("Invalid Arguments");
            }
        }

        private static bool validateParseNumberBase(string inputNumber, double numberBase)
        {
            double value;
            foreach (char c in inputNumber)
            {
                try {
                    value = Char.GetNumericValue(c);
                    if (value >= numberBase) return false;
                } catch
                {
                    return false;
                }
            }
            return true;
        }

        private static double convertNumToBaseTen(string num, double numBase)
        {
            double sum = 0;
            int j = 0;

            for (int i = num.Length - 1; i > -1; i--)
            {
                sum += Char.GetNumericValue(num[i]) * Math.Pow(numBase, j);
                j++;
            }

            return sum;
        }

        private static string convertNumToBase(int num, double targetBase)
        {
            string result = String.Empty;

            while (num > 0)
            {
                int remainder = (int)(num % targetBase);
                result = remainder + result;
                num = (int)(num / targetBase);
            }

            return result;
        }
    }
}
