using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uebung19
{
    class Erode {
        private byte[,] _structuringElement;

        public Erode(byte[,] structuringElement)
        {
            this._structuringElement = structuringElement;
        }

        public byte[,] execute(byte[,] image, byte threshhold = 1)
        {
            byte[,] filteredImage = new byte[image.GetLength(0), image.GetLength(1)];

            for (int x = 0; x < image.GetLength(0); x++)
            {
                for (int y = 0; y < image.GetLength(1); y++)
                {
                    if (image[x, y] >= threshhold)
                    {
                        setFilterAtPoint(ref filteredImage, x, y);
                    }
                }
            }
            return filteredImage;
        }

        private byte[,] setFilterAtPoint(ref byte[,]image, int x, int y)
        {
            int posX, posY, filterX, filterY;
            int filterOffset = (this._structuringElement.GetLength(0) - 1) / 2;
            int filterWidth = this._structuringElement.GetLength(0);
            int filterHeight = this._structuringElement.GetLength(1);

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
                        image[posX, posY] = this._structuringElement[filterX, filterY];
                    }
                }
            }
            return image;
        }
    
    }
}
