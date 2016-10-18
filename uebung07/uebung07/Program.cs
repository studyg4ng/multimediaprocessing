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

namespace uebung07 {
    class Program {
        static void Main(string[] args) {
            MSECalculator calculator = new MSECalculator(@"../../media/Lena_q10.jpg", @"../../media/Lena_q5.jpg");
            calculator.printMSE();

            MSECalculator calculatorOriginal = new MSECalculator(@"../../media/Lena.png", @"../../media/Lena_q5.jpg");
            calculatorOriginal.printMSE();

            MSECalculator calculatorBlackWhite = new MSECalculator(@"../../media/black.jpg", @"../../media/white.jpg");
            calculatorBlackWhite.printMSE();

            MSECalculator calculatorSame = new MSECalculator(@"../../media/Lena.png", @"../../media/Lena.png");
            calculatorSame.printMSE();
        }
    }
}
