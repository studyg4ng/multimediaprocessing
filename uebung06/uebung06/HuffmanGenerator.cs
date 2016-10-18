using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObSi;

namespace uebung06 {
    class HuffmanGenerator {
        string _inputFilePath, _outputFilePath;

        public HuffmanGenerator(string inputFilePath, string outputFilePath) {
            this._inputFilePath = inputFilePath;
            this._outputFilePath = outputFilePath;
        }

        public string generateHuffmanCode() {
            HuffmanTree tree = generateHuffmanTree();
            Dictionary<char, string> codeTable = tree.generateDictionary();
            string code = "";

            foreach(char c in getFileContent(this._inputFilePath)) code += codeTable[c];

            return code;
        }

        public HuffmanTree generateHuffmanTree() {
            HuffmanTree tree = new HuffmanTree();
            HuffmanNode parentNode;
            HuffmanNode leftNode;
            HuffmanNode rightNode;

            PriorityQueue<HuffmanNode> queue = new PriorityQueue<HuffmanNode>();
            string inputFileContent = getFileContent(this._inputFilePath);
            Dictionary<char, uint> dict = getCharAbsFrequency(inputFileContent);
            
            foreach(char key in dict.Keys) {
                queue.Enqueue(new HuffmanNode(dict[key], key, true));
                // Console.WriteLine("Data: {0}, Char: {1}", dict[key], key);
            }

            while(queue.Count() > 1) {
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

        private Dictionary<char, uint> getCharAbsFrequency(string input) {
            Dictionary<char, uint> dict = new Dictionary<char, uint>();

            foreach(char c in input) {
                if(!dict.ContainsKey(c)) dict.Add(c, 1);
                else dict[c]++;
            }
            return dict;
        }

        private static string getFileContent(string inputFilePath) {
            return FileIO.getFileContent(inputFilePath);
        }

        public void WriteHuffmanTreeToFile() {
            string content = generateHuffmanCode();
            FileIO.writeOutputFile(this._outputFilePath, content);
        }
    }
}
