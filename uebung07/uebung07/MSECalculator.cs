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
using System.Drawing;
using ObSi;

namespace uebung07 {
    class MSECalculator {
        Bitmap _imageA, _imageB;

        public MSECalculator(string filePath1, string filePath2) {
            _imageA = (Bitmap)FileIO.getImageFromFile(filePath1);
            _imageB = (Bitmap)FileIO.getImageFromFile(filePath2);
        }

        public double calculateMSE() {
            double diffRed, diffGreen, diffBlue, squareDiff = 0, mse = 0, pixels;

            for (int x = 0; x < _imageA.Width; x++)
            {
                for (int y = 0; y < _imageA.Height; y++)
                {
                    Color colorA = _imageA.GetPixel(x, y);
                    Color colorB = _imageB.GetPixel(x, y);

                    diffRed = Math.Abs(colorA.R - colorB.R);
                    diffGreen = Math.Abs(colorA.G - colorB.G);
                    diffBlue = Math.Abs(colorA.B - colorB.B);
                    squareDiff += Math.Pow(diffRed, 2) + Math.Pow(diffGreen, 2) + Math.Pow(diffBlue, 2);
                }
            }

            pixels = (_imageA.Width * _imageA.Height * 3);
            mse = squareDiff / pixels;

            return Math.Pow(mse, 0.5d);
        }

        public void printMSE() {
            Console.WriteLine("MSE: {0:00.00}", calculateMSE());
        }
    }
}
