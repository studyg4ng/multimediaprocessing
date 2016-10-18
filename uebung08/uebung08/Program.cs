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

namespace uebung08 {
    class Program {
        static void Main() {
            HistogrammCalculator histocalc = new HistogrammCalculator(@"../../media/Lena.png", @"../../media/Lena.csv");
            histocalc.writeCSV();
        }
    }
}
