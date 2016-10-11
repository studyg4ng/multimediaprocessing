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
using System.IO;

namespace uebung06 {
    class Program {
        public static void Main(string[] args) {
            if (!doTests()) Console.WriteLine("Test failed!");
            else
            {
                if (args.Length != 2) Console.WriteLine("Invalid Arguments! (Syntax: <file_to_analyse> <result_txt>)");
                else
                {
                    string fileContent = getFileContent(@args[0]);
                    Dictionary<char, uint> myContent = getCharAbsFrequency(fileContent);
                    HuffmanTree tree = generateHuffmanTree(myContent);
                    string huffmanCode = generateHuffmanCode(fileContent, tree.generateDictionary());
                    writeOutputFile(@args[1], huffmanCode);
                    Console.WriteLine("FINISHED. Please press a key!");
                    Console.ReadKey();
                }
            }
        }

        private static bool doTests() {
            string inputFile = @"../../test/input.txt";
            string outputFile = @"../../test/output.txt";

            if (getFileContent(inputFile).Length == 0) return false;
            string fileContent = getFileContent(inputFile);
            Dictionary<char, uint> dict = getCharAbsFrequency(fileContent);

            if (dict.Count != 8) return false;
            if (dict['d'] != 2) return false;
            if (File.Exists(outputFile)) File.Delete(outputFile); // Delete previous generated test outputFile
            writeOutputFile(outputFile, "testing ...");
            if (!File.Exists(outputFile)) return false;
            return true;
        }

        private static string generateHuffmanCode(string input, Dictionary<char, string> codeTable) {
            string code = "";

            foreach (char c in input) code += codeTable[c];

            return code;
        }

        private static HuffmanTree generateHuffmanTree(Dictionary<char, uint> dict) {
            HuffmanTree tree = new HuffmanTree();
            HuffmanNode parentNode;
            HuffmanNode leftNode;
            HuffmanNode rightNode;

            PriorityQueue<HuffmanNode> queue = new PriorityQueue<HuffmanNode>();

            foreach (char key in dict.Keys)
            {
                queue.Enqueue(new HuffmanNode(dict[key], key, true));
                // Console.WriteLine("Data: {0}, Char: {1}", dict[key], key);
            }

            while (queue.Count() > 1)
            {
                leftNode = queue.Dequeue();
                rightNode = queue.Dequeue();
                parentNode = new HuffmanNode(leftNode.data + rightNode.data, new char(), false);

                parentNode.leftChild = leftNode;
                parentNode.rightChild = rightNode;
                queue.Enqueue(parentNode);
            }

            tree.root = queue.Dequeue();
            return tree;
        }

        private static Dictionary<char, uint> getCharAbsFrequency(string input) {
            Dictionary<char, uint> dict = new Dictionary<char, uint>();

            foreach (char c in input)
            {
                if (!dict.ContainsKey(c)) dict.Add(c, 1);
                else dict[c]++;
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
            else throw new FileNotFoundException(String.Format("File [{0}] not Found!", filePath));
        }

        private static void writeOutputFile(string filePath, string content) {
            if (File.Exists(filePath)) File.Delete(filePath);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(content);
                writer.Flush();
            }
        }
    }
}
