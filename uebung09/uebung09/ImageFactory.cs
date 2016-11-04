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
    class ImageFactory {
        private static ImageFactory _factory;

        private ImageFactory() { }

        public static ImageFactory getInstace() {
            if (ImageFactory._factory == null) return ImageFactory._factory = new ImageFactory();
            else return ImageFactory._factory;
        }

        public void manipulateImage(string srcPath, string manipulationType) {
            switch (manipulationType) {
                case "1":
                    IManipulate inverter = new ImageInverter(srcPath);
                    inverter.manipulateAndSafe();
                    break;
                case "2":
                    clamp(srcPath);
                    break;
                case "3":
                    multiplyBy4AndClamp(srcPath);
                    break;
                case "4":
                    quantBy16(srcPath);
                    break;
                case "5":
                    threshouldWith128(srcPath);
                    break;
                default:
                    break;
            }
        }

        public void clamp(string srcPath) { }
        public void multiplyBy4AndClamp(string srcPath) { }
        public void quantBy16(string srcPath) { }
        public void threshouldWith128(string srcPath) { }
    }
}
