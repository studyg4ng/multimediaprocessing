using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace uebung06
{
    class HuffmanNode : IComparable
    {
        public HuffmanNode leftChild;
        public HuffmanNode rightChild;
        // public HuffmanNode parent;

        public uint data; // frequency
        public char charA; // own char or *

        public HuffmanNode(uint data, char charA)
        {
            this.data = data;
            this.charA = charA;
        }

        public int CompareTo(object obj)
        {
            HuffmanNode other = (HuffmanNode)obj;
            return this.data.CompareTo(other.data);
        }

    }

    class HuffmanNodeComparer : IComparer<HuffmanNode>
    {
        public int Compare(HuffmanNode x, HuffmanNode y)
        {
            return x.data.CompareTo(y.data);
        }
    }

    class HuffmanTree
    {
        public HuffmanNode root;

        public List<HuffmanNode> toList()
        {
            List<HuffmanNode> nodes = new List<HuffmanNode>();
            Stack<HuffmanNode> nodeStack = new Stack<HuffmanNode>();

            nodeStack.Push(root);

            while (!(nodeStack.Count == 0))
            {
                HuffmanNode currentNode = nodeStack.Pop();
                if (currentNode.charA != '*') nodes.Add(currentNode);

                if (currentNode.leftChild != null) nodeStack.Push(currentNode.leftChild);
                if (currentNode.rightChild != null) nodeStack.Push(currentNode.rightChild);
            }

            return nodes;
        }
    }
}
