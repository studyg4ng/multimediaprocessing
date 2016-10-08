using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace uebung06 {
    class HuffmanNode {
        HuffmanNode leftChild;
        HuffmanNode rightChild;

        HuffmanNode parent;
        bool isFinalNode;
        char data;
    }

    class HuffmanTree {
        HuffmanNode root;  
    }
}
