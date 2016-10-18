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

namespace uebung08 {
    class HistogrammCalculator {
        private Bitmap _image;
        private string _outputPath;
        private string _inputPath;

        public HistogrammCalculator(string inputPath, string outputPath) {
            this._inputPath = inputPath;
            this._outputPath = outputPath;
        }

        private SortedDictionary<byte, uint> getAbsChannelFrequency() { // <value, count>
            SortedDictionary<byte, uint> dict = new SortedDictionary<byte, uint>();
            byte redValue;

            this._image = (Bitmap)FileIO.getImageFromFile(this._inputPath);

            for (int x = 0; x < _image.Width; x++) {
                for (int y = 0; y < _image.Height; y++) {
                    redValue = _image.GetPixel(x, y).R;
                    if (dict.ContainsKey(redValue)) dict[redValue]++;
                    else dict.Add(redValue, 1);
                }
            }
            return dict;
        }

        public void writeCSV() {
            SortedDictionary<byte, uint> dict = getAbsChannelFrequency();

              string content = "";

            foreach (byte key in dict.Keys) {
                content += String.Format("{0};{1}\n", key, dict[key]);
            }

            FileIO.writeOutputFile(this._outputPath, content);
        }
    }
}
