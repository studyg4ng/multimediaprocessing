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
            if (args.Length != 2) Console.WriteLine("Invalid Arguments! (Syntax: <file_to_analyse> <result_txt>)");
            else {
                HuffmanGenerator huffGen = new HuffmanGenerator(args[0], args[1]);
                HuffmanTree tree = huffGen.generateHuffmanTree();
                huffGen.WriteHuffmanTreeToFile();

                Console.WriteLine("FINISHED. Please press a key!");
                Console.ReadKey();
            }
        }

        /*private static bool doTests() {
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
        }*/
    }
}
