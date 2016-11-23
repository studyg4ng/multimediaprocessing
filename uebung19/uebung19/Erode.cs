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

namespace uebung19
{
    class Erode {
        private byte[,] _erodeMatrix;

        public Erode(byte[,] _erodeMatrix)
        {
            this._erodeMatrix = _erodeMatrix;
        }

        public byte[,] execute(byte[,] image, byte threshhold = 1)
        {
            byte[,] filteredImage = (byte[,]) image.Clone();

            for (int x = 0; x < image.GetLength(0); x++)
            {
                for (int y = 0; y < image.GetLength(1); y++)
                {
                    if (image[x, y] < threshhold)
                    {
                        applyErodeMatrix(ref filteredImage, x, y);
                    }
                }
            }
            return filteredImage;
        }

        private byte[,] applyErodeMatrix(ref byte[,]image, int x, int y)
        {
            int posX, posY, filterX, filterY;
            int filterOffset = (this._erodeMatrix.GetLength(0) - 1) / 2;
            int filterWidth = this._erodeMatrix.GetLength(0);
            int filterHeight = this._erodeMatrix.GetLength(1);

            for (int offsetX = -filterOffset; offsetX <= filterOffset; offsetX++)
            {
                for (int offsetY = -filterOffset; offsetY <= filterOffset; offsetY++)
                {
                    posX = x + offsetX; // Image Position
                    posY = y + offsetY; // Image Position
                    filterX = filterOffset + offsetX; // Filter Position
                    filterY = filterOffset + offsetY; // Filter Position
                    if (posX >= 0 && posX < image.GetLength(0) && posY >= 0 && posY < image.GetLength(0))
                    {
                        if(image[posX, posY] > 0 && this._erodeMatrix[filterX, filterY] > 0)
                        {
                            image[posX, posY] = 0;
                            //image[posX, posY] = this._structuringElement[filterX, filterY];
                        }
                    }
                }
            }
            return image;
        }
    
    }
}
