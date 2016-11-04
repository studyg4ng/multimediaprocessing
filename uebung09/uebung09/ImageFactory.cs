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
using System.Media;

namespace uebung09 {
    class ImageEditor {
        private Bitmap _image;
        private string _destPath;

        public ImageEditor(string srcPath, string destPath) {
            this._image = (Bitmap)FileIO.getImageFromFile(srcPath);
            this._destPath = destPath;
        }

        public Bitmap getInvertedBitmapFromImage() {
            Bitmap invertedBitmap = new Bitmap(this._image.Width, this._image.Height);
            byte inverted_R, inverted_G, inverted_B;
            Color pixelCol, invertedPixelColor;

            for (int x = 0; x < _image.Width; x++) {
                for (int y = 0; y < _image.Width; y++) {
                    pixelCol = _image.GetPixel(x, y);
                    invertedPixelColor = new Color();

                    inverted_R = (byte)(255 - pixelCol.R);
                    inverted_G = (byte)(255 - pixelCol.G);
                    inverted_B = (byte)(255 - pixelCol.B);

                    //invertedPixelColor.

                    //invertedBitmap.SetPixel(x, y, invertedPixelColor);
                }
            }

            return invertedBitmap;
        }
    }
}
