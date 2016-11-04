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
using ObSi;
using System.Drawing;
using System.Threading;

namespace uebung09 {
    class Program {
        static void Main(string[] args) {
            Console.ForegroundColor = ConsoleColor.White;
            while (1 == 1) {
                // introduction
                Console.WriteLine("Welcome to the ImageEditor! Type in 1, 2, 3, 4 or 5 to choose the filter.");
                Console.WriteLine("Invert (1), Clamp (2), MultiplyAndClamp (3), UniformQuantize (4), Threshold (5)");
                Console.WriteLine("***Press STRG + C to exit program.***");

                // user input
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                string inputType = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                // check types
                string validTypes = "12345";
                foreach (char c in validTypes) {
                    if (inputType.Length > 0 && inputType[0] == c) {
                        handleInput("../../media/lion.jpg", inputType);
                        break;
                    }
                }
            }
        }

        public static void saveToFile(Bitmap bitmap) {
            bitmap.Save("../../media/out.png");
        }

        public static void handleInput(string srcPath, string manipulationType) {
            Filter filter = null;

            switch (manipulationType) {
                case "1":
                    filter = new Invert(srcPath);
                    break;
                case "2":
                    filter = new Clamp(srcPath, 75, 180);
                    break;
                case "3":
                    filter = new MultiplyAndClamp(srcPath, 4, 2, 253);
                    break;
                case "4":
                    filter = new UniformQuantize(srcPath, 32, 32);
                    break;
                case "5":
                    filter = new Threshold(srcPath, 255);
                    break;
                default:
                    Console.WriteLine("Need proper input.");
                    break;
            }

            if (filter != null) {
                saveToFile(filter.invertImage());

                Console.WriteLine("Using: {0}-Filter.", filter.GetType().ToString().Substring(filter.GetType().ToString().IndexOf('.') + 1));
                Console.ForegroundColor = ConsoleColor.DarkCyan;

                for (int i = 0; i < 10; i++) {
                    Thread.Sleep(200);
                    Console.Write(".");
                }

                Console.Write(" finish! \n\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
