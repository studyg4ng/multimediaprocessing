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

namespace uebung02 {
    class Program {
        static void Main(string[] args) {
            string[] numbers;
            double numberBase;
            double baseTarget;

            if(validateInput(args, out numbers, out numberBase, out baseTarget)) {
                double numToBaseTen = convertNumToBaseTen(numbers, numberBase);
                Console.WriteLine("Result: " + convertNumToBase((int)numToBaseTen, baseTarget));
            }
            else {
                Console.WriteLine("Couldn't Parse Arguments");
            }
        }

        private static bool validateInput(string[] inputArgs, out string[] numbers, out double numberBase, out double baseTarget) {
            numberBase = -1;
            baseTarget = -1;
            numbers = new string[1];

            if(inputArgs.Length == 0) return false;
            if(inputArgs.Length != 3) {
                Console.WriteLine("Invalid Argumentlength: [{}]", String.Join(" ", inputArgs));
                return false;
            }

            numbers = inputArgs[0].Split(',');

            if(double.TryParse(inputArgs[1], out numberBase) && double.TryParse(inputArgs[2], out baseTarget)) {
                foreach(string number in numbers) {
                    if(!validateParseNumberBase(number, numberBase)) return false;
                }
            }
            return true;
        }

        private static bool validateParseNumberBase(string inputNumber, double numberBase) {
            double value;
            foreach(char c in inputNumber) {
                try {
                    value = Char.GetNumericValue(c);
                    if(value >= numberBase) return false;
                }
                catch {
                    return false;
                }
            }
            return true;
        }

        private static double convertNumToBaseTen(string[] num, double numBase)
        {
            double sum = 0;
            int j = 0;

            for (int i = num.Length - 1; i > -1; i--)
            {
                sum += Int32.Parse(num[i]) * Math.Pow(numBase, j);
                j++;
            }

            return sum;
        }

        private static string convertNumToBase(int num, double targetBase)
        {
            LinkedList<string> result = new LinkedList<string>();

            while (num > 0)
            {
                int remainder = (int)(num % targetBase);
                result.AddFirst(remainder.ToString());
                num = (int)(num / targetBase);
            }

            return String.Join(",", result);
        }
    }
}
