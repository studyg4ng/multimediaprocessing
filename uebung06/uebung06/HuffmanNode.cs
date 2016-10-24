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
using System.IO;

namespace uebung06 {
    class HuffmanNode : IComparable {
        public HuffmanNode leftChild, rightChild;
        public string path;
        public bool isLeaf;

        public uint data; // frequency
        public char charA;

        public HuffmanNode(uint data, char charA, bool isLeaf) {
            this.data = data;
            this.charA = charA;
            this.isLeaf = isLeaf;
        }

        public int CompareTo(object obj) {
            HuffmanNode other = obj as HuffmanNode;
            return this.data.CompareTo(other.data);
        }
    }
}