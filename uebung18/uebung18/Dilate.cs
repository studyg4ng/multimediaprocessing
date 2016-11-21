using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uebung18
{
    class Dilate {
        byte[,] dilateFilter = new byte[3, 3] {
            { 1, 1, 1 },
            { 1, 1, 1 },
            { 1, 1, 1 }
        };
        private byte[,] _imageArray;

        public Dilate(byte[,] imageArray)
        {
            this._imageArray = imageArray;
        }

        public byte[,] execute()
        {
            byte[,] dilate = new byte[this._imageArray.GetLength(0), this._imageArray.GetLength(1)];

            for(int i = 0; i < this._imageArray.GetLength(0) - 1; i++)
            {
                for(int j = 0; j < this._imageArray.GetLength(1) - 1; j++)
                {
                    if(this._imageArray[i,j] > 0)
                    {
                        dilate[i, j] = 1;
                        dilate[i - 1, j - 1] = 1;
                        dilate[i, j - 1] = 1;
                        dilate[i - 1, j] = 1;
                        dilate[i + 1, j - 1] = 1;
                        dilate[i - 1, j + 1] = 1;
                        dilate[i + 1, j + 1] = 1;
                        dilate[i + 1, j] = 1;
                        dilate[i, j + 1] = 1;
                    }
                }
            }
            return dilate;
        }


    
    }
}
