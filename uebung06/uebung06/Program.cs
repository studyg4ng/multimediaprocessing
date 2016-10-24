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
            else
            {
                HuffmanGenerator huffGen = new HuffmanGenerator(args[0], args[1]);
                HuffmanTree tree = huffGen.generateHuffmanTree();
                huffGen.WriteHuffmanTreeToFile();

                Console.WriteLine("FINISHED. Please press a key!");
                Console.ReadKey();
            }
        }
    }
}
