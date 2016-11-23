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

namespace uebung18 {
    class Dilate {
        private byte[,] _filterMatrix;

        public Dilate(byte[,] filter) {
            this._filterMatrix = filter;
        }

        public byte[,] execute(byte[,] image, byte threshhold = 1) {
            byte[,] filteredImage = new byte[image.GetLength(0), image.GetLength(1)];

            for (int x = 0; x < image.GetLength(0); x++) {
                for (int y = 0; y < image.GetLength(1); y++) {
                    if (image[x, y] >= threshhold) {
                        setFilterAtPoint(ref filteredImage, x, y);
                    }
                }
            }
            return filteredImage;
        }

        private byte[,] setFilterAtPoint(ref byte[,] image, int x, int y) {
            int posX, posY, filterX, filterY;
            int filterOffset = (this._filterMatrix.GetLength(0) - 1) / 2;
            int filterWidth = this._filterMatrix.GetLength(0);
            int filterHeight = this._filterMatrix.GetLength(1);

            for (int offsetX = -filterOffset; offsetX <= filterOffset; offsetX++) // width
            {
                for (int offsetY = -filterOffset; offsetY <= filterOffset; offsetY++) // height
                {
                    posX = x + offsetX; // Image Position
                    posY = y + offsetY; // Image Position
                    filterX = filterOffset + offsetX; // Filter Position
                    filterY = filterOffset + offsetY; // Filter Position
                    if (posX >= 0 && posX < image.GetLength(0) && posY >= 0 && posY < image.GetLength(1)) {
                        if (this._filterMatrix[filterX, filterY] != 0) image[posX, posY] = this._filterMatrix[filterX, filterY]; // 0 in filter does not override image
                    }
                }
            }
            return image;
        }
    }
}
