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

        public static void manipulateImage(string srcPath, string destPath, string manipulationType) {
            switch (manipulationType) {
                case "1":
                    IManipulate inverter = new InvertImage(srcPath);
                    inverter.manipulateAndSafe(destPath);
                    break;
                case "2":
                    clamp(srcPath, destPath);
                    break;
                case "3":
                    multiplyBy4AndClamp(srcPath, destPath);
                    break;
                case "4":
                    quantBy16(srcPath, destPath);
                    break;
                case "5":
                    threshouldWith128(srcPath, destPath);
                    break;
                default:
                    break;
            }
        }

        public static void clamp(string srcPath, string destPath) { }
        public static void multiplyBy4AndClamp(string srcPath, string destPath) { }
        public static void quantBy16(string srcPath, string destPath) { }
        public static void threshouldWith128(string srcPath, string destPath) { }
    }
}
