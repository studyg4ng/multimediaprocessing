/*1510601027 fhs38532
  Thomas Siller
  -------------------
  1510601032 fhs38596
  Patrick Obermüller*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ObSi;

namespace uebung09 {
    class InvertImage : IManipulate {
        private Bitmap _bitmap;

        public InvertImage(string srcPath) {
            this._bitmap = (Bitmap)FileIO.getImageFromFile2(srcPath);
        }

        private Bitmap invertImage() {
            Bitmap bitmap = new Bitmap(this._bitmap.Width, this._bitmap.Height);
            byte inverted_R, inverted_G, inverted_B;
            Color pixelCol, invertedPixelColor;

            for (int x = 0; x < this._bitmap.Width; x++) {
                for (int y = 0; y < this._bitmap.Height; y++) {
                    pixelCol = this._bitmap.GetPixel(x, y);
                    invertedPixelColor = new Color();

                    inverted_R = (byte)(255 - pixelCol.R);
                    inverted_G = (byte)(255 - pixelCol.G);
                    inverted_B = (byte)(255 - pixelCol.B);

                    invertedPixelColor = Color.FromArgb(inverted_R, inverted_G, inverted_B);

                    bitmap.SetPixel(x, y, invertedPixelColor);
                }
            }
            return bitmap;
        }

        public void manipulateAndSafe(string destPath) {
            Bitmap invertedBitmap = invertImage();
            invertedBitmap.Save(destPath);
        }
    }
}
