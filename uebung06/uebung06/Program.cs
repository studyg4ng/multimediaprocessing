using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using VCSKicksCollection;

namespace uebung06
{
    class Program
    {
        public static void Main(string[] args)
        {

            if (args.Length != 2)
            {
                Console.WriteLine("Invalid Arguments! (Syntax: <file_to_analyse> <result_csv>)");
            }
            else
            {
                string fileContent = getFileContent(@args[0]);
                Dictionary<char, uint> myContent = getCharAbsFrequency(fileContent);
                generateHuffmanTree(myContent);
                Console.ReadKey();
            }

            /*if (!doTests()) {
                Console.WriteLine("Test failed!");
            }
            else {
                if (args.Length != 2) {
                    Console.WriteLine("Invalid Arguments! (Syntax: <file_to_analyse> <result_csv>)");
                }
                else {
                    string fileContent = getFileContent(@args[0]);
                    string csv = generateCSVString(getCharEntropy(getCharAbsFrequency(fileContent), fileContent.Length));
                    writeOutputFile(@args[1], csv);
                    Console.WriteLine("FINISHED. Please press a key!");
                    Console.ReadKey();
                }
            }*/
        }

        private static bool doTests()
        {
            string inputFile = @"../../test/input.txt";
            string outputFile = @"../../test/output.csv";

            if (getFileContent(inputFile).Length == 0) return false;
            string fileContent = getFileContent(inputFile);
            Dictionary<char, uint> dict = getCharAbsFrequency(fileContent);

            if (dict.Count != 4) return false;
            if (dict['d'] != 2) return false;
            //if (getCharEntropy(dict, fileContent.Length)['a'] != 20) return false;
            if (File.Exists(outputFile)) File.Delete(outputFile); // Delete previous generated test outputFile
            writeOutputFile(outputFile, "test1123");
            if (!File.Exists(outputFile)) return false;
            return true;
        }

        private Dictionary<char, string> generateHuffmanCodeTable(HuffmanTree tree)
        {
            Dictionary<char, string> huffmanTable = new Dictionary<char, string>();
            return huffmanTable;
        }

        private static HuffmanTree generateHuffmanTree(Dictionary<char, uint> dict)
        {
            HuffmanTree tree = new HuffmanTree();
            PriorityQueue<HuffmanNode> queue = new PriorityQueue<HuffmanNode>();

            foreach (char key in dict.Keys)
            {
                queue.Enqueue(new HuffmanNode(dict[key], key));
            }

            while (queue.Count() > 1)
            {
                HuffmanNode num1 = queue.Dequeue();
                HuffmanNode num2 = queue.Dequeue();
                HuffmanNode parentNode = new HuffmanNode(num1.data + num2.data, '*');

                parentNode.leftChild = num1;
                parentNode.rightChild = num2;
                queue.Enqueue(parentNode);
                // Console.WriteLine("data:" + num1.data + " | char:" + num1.charA);
            }

            tree.root = queue.Dequeue();

            return tree;
        }

        #region Logic
        private static Dictionary<char, uint> getCharAbsFrequency(string input)
        {
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

        private static Dictionary<char, double> getCharEntropy(Dictionary<char, uint> absDict, int charCount)
        {
            Dictionary<char, double> dict = new Dictionary<char, double>();
            double tmp;

            foreach (char key in absDict.Keys)
            {
                tmp = ((double)absDict[key] / charCount);
                dict[key] = -tmp * Math.Log(tmp); // percentage
            }

            return dict;
        }
        #endregion

        #region FileIO
        private static string generateCSVString(Dictionary<char, double> dict)
        {
            StringBuilder builder = new StringBuilder();

            foreach (char key in dict.Keys)
            {
                builder.Append(String.Format("{0} [{1}];{2}\n", key, (int)key, dict[key]));
            }

            return builder.ToString();
        }

        private static string getFileContent(string filePath)
        {
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

        private static void writeOutputFile(string filePath, string content)
        {
            if (File.Exists(filePath)) File.Delete(filePath);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(content);
                writer.Flush();
            }
        }
        #endregion
    }
}
