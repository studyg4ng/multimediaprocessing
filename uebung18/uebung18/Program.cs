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
using System.Diagnostics;

namespace uebung18 {
    class Program {
        static void Main(string[] args) {

            #region InitDefaultFilter
            byte[,] dilate = new byte[3, 3] {
                { 1, 1, 1 },
                { 1, 1, 1 },
                { 1, 1, 1 }
            };

            Dilate dil = new Dilate(dilate);
            #endregion

            #region InitImageDummies

            byte[,] imageA = new byte[11, 11] {
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 }
            };

            byte[,] filledImage = new byte[11, 11] {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
            };
            #endregion

            #region Test1 
            byte[,] imageAFilteredSolution = new byte[11, 11] {
                { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                { 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0 },
                { 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0 },
                { 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0 }
            };

            byte[,] filteredImageA = dil.execute(imageA);
            compareImages(filteredImageA, imageAFilteredSolution);
            #endregion

            #region Test2 
            byte[,] filteredImageB = dil.execute(filledImage);
            compareImages(filteredImageB, filledImage);
            #endregion

            #region InitCrossFilter
            byte[,] crossDilate = new byte[3, 3] {
                { 0, 1, 0 },
                { 1, 1, 1 },
                { 0, 1, 0 }
            };

            Dilate dilateCross = new Dilate(crossDilate);
            #endregion

            #region CrossFilterTest1
            byte[,] crossSolutionA = new byte[11, 11] {
                { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                { 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0 },
                { 0, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0 }
            };

            byte[,] crossFilteredImageA = dilateCross.execute(imageA);
            compareImages(crossFilteredImageA, crossSolutionA);
            #endregion

            #region CrossFilterTest2
            byte[,] crossFilteredImageB = dilateCross.execute(filledImage);
            compareImages(crossFilteredImageB, filledImage);
            #endregion

            Console.WriteLine("");
        }

        private static void compareImages(byte[,] imageA, byte[,] imageB) {
            int width = imageA.GetLength(0);
            int height = imageA.GetLength(0);

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    Debug.Assert(imageA[x, y].Equals(imageB[x, y]));
                }
            }
        }
    }
}