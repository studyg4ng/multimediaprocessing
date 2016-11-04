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

namespace uebung09 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Syntax: <number> <img1>");
            ImageFactory.getInstace();

            ImageFactory.manipulateImage("../../media/lion.jpg", "../../media/lion_inverted.jpg", "1");
        }
    }
}
