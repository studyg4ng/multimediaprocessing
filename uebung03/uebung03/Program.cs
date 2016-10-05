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

namespace uebung03
{
    class Program
    {
        static string[,] myContent = {
                {"A","01001"},
                {"F","10"},
                {"I","01000"},
                {"M","0111"},
                {"N","0101"},
                {"O","11"},
                {"R","0110"},
                {"T","00"},
            };
        //static string code = "01000010110110110011101001000100011010101";

        static Dictionary<string, char> myDict;
        static int longestCharKey = 0;

        static void Main(string[] args)
        {
            initDict();
            if(args.Length == 1)
            {
                if (validateInput(args[0])) encodeAndPrint(args[0]);
                else Console.WriteLine("Ungültiges Zeichen in der Eingabe!");
            } else
            {
                Console.WriteLine("Argumente Ungültig. Nur ein Argument erlaubt.");
            }
       
        }

        private static void initDict()
        {
            myDict = new Dictionary<string, char>();
            longestCharKey = 0;

            for (int i = 0; i < myContent.GetLength(0); i++)
            {
                if (longestCharKey < myContent[i, 1].Length) longestCharKey = myContent[i, 1].Length;
                myDict.Add(myContent[i, 1], myContent[i, 0][0]);
            }
        }

        private static bool validateInput(string code)
        {
            foreach(char c in code)
            {
                if (c != '0' && c != '1') return false;
            }
            return true;
        }

        private static void encodeAndPrint(string code)
        {

            string result = "";
            int currentLength = 1;
            int currentIndex = 0;
            string currentKey;

            // encode
            while (currentIndex + currentLength <= code.Length)
            {
                currentKey = code.Substring(currentIndex, currentLength);
                if (myDict.ContainsKey(currentKey))
                {
                    currentIndex += currentLength;
                    currentLength = 1;
                    result += myDict[currentKey];
                }
                else
                {
                    currentLength++;
                }
            }

            // validate result
            if (currentLength > longestCharKey)
            {
                Console.WriteLine("Fehlerhafter Code: {0}", code.Substring(currentIndex, currentLength - 1));
            }

            if (currentIndex != code.Length)
            {
                Console.WriteLine("Code um {0} Zeichen zu lange. Zeichenfolge: [{1}]", code.Length - currentIndex, code.Substring(currentIndex, code.Length - currentIndex));
            }
            Console.WriteLine("Ergebnis: [{0}]", result);
        }
    }
}
