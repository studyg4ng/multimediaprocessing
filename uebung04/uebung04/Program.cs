/*1510601027 fhs38532
  Thomas Siller
  -------------------
  1510601032 fhs38596
  Patrick Obermüller*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uebung01 {
    class Program {
        public static double checkSum = 0d;

        public static void Main(string[] args) {
            if (!doTests())
            {
                Console.WriteLine("Test failed!");
            }
            else
            {
                if (args.Length != 2)
                {
                    Console.WriteLine("Invalid Arguments! (Syntax: <file_to_analyse> <result_csv>)");
                }
                else
                {
                    string fileContent = getFileContent(@args[0]);
                    string csv = generateCSVString(getCharRelFrequency(getCharAbsFrequency(fileContent), fileContent.Length));
                    writeOutputFile(@args[1], csv);
                    Console.WriteLine("FINISHED. Please press a key!");
                    Console.ReadKey();
                }
            }
        }

        private static bool doTests() {
            string inputFile = @"../../test/input.txt";
            string outputFile = @"../../test/output.csv";

            if (getFileContent(inputFile).Length == 0) return false;
            string fileContent = getFileContent(inputFile);
            Dictionary<char, uint> dict = getCharAbsFrequency(fileContent);

            if (dict.Count != 4) return false;
            if (dict['d'] != 2) return false;
            if (getCharRelFrequency(dict, fileContent.Length)['a'] != 20) return false;
            if (File.Exists(outputFile)) File.Delete(outputFile); // Delete previous generated test outputFile
            writeOutputFile(outputFile, "test1123");
            if (!File.Exists(outputFile)) return false;
            return true;
        }

        private static string generateCSVString(Dictionary<char, double> dict) {
            StringBuilder builder = new StringBuilder();

            foreach (char key in dict.Keys)
            {
                builder.Append(String.Format("{0} [{1}]; {2}% \n", key, (int)key, dict[key]));
            }

            return builder.ToString();
        }

        private static Dictionary<char, uint> getCharAbsFrequency(string input) {
            Dictionary<char, uint> dict = new Dictionary<char, uint>();

            foreach (char c in input)
            {
                if (!dict.ContainsKey(c))
                {
                    dict.Add(c, 1);
                }
                else
                {
                    dict[c]++;
                }
            }

            return dict;
        }

        private static Dictionary<char, double> getCharRelFrequency(Dictionary<char, uint> absDict, int charCount) {
            Dictionary<char, double> dict = new Dictionary<char, double>();

            foreach (char key in absDict.Keys)
            {
                dict[key] = ((double)absDict[key] / charCount) * 100; // percentage
                checkSum += dict[key];
            }

            return dict;
        }

        private static string getFileContent(string filePath) {
            string content = "";
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    content = reader.ReadToEnd();
                    return content;
                }
            }
            else
            {
                throw new FileNotFoundException(String.Format("File [{0}] not Found!", filePath));
            }
        }

        private static void writeOutputFile(string filePath, string content) {
            if (File.Exists(filePath)) File.Delete(filePath);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(content);
                writer.Write(String.Format("; CheckSum: {0:00.00}% ", (checkSum / 2))); // divided because of the executed test method --> 200%
                writer.Flush();
            }
        }
    }
}
