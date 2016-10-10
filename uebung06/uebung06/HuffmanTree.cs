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
        public string path;
        public bool isLeaf;

        public uint data; // frequency
        public char charA;

        public HuffmanNode(uint data, char charA, bool isLeaf)
        {
            this.data = data;
            this.charA = charA;
            this.isLeaf = isLeaf;
        }

        public int CompareTo(object obj)
        {
            HuffmanNode other = (HuffmanNode)obj;
            return this.data.CompareTo(other.data); // uint implementation
        }
    }

    class HuffmanTree
    {
        public HuffmanNode root;

        public Dictionary<char, string> generateDictionary()
        {
            Dictionary<char, string> dict = new Dictionary<char, string>();
            Stack<HuffmanNode> nodeStack = new Stack<HuffmanNode>();
            HuffmanNode currentNode;

            nodeStack.Push(root);

            while (!(nodeStack.Count == 0))
            {
                currentNode = nodeStack.Pop();
                if (currentNode.isLeaf) dict.Add(currentNode.charA, currentNode.path);
                else
                {
                    if (currentNode.leftChild != null)
                    {
                        currentNode.leftChild.path = currentNode.path + "0";
                        nodeStack.Push(currentNode.leftChild);
                    }
                    if (currentNode.rightChild != null)
                    {
                        currentNode.rightChild.path = currentNode.path + "1";
                        nodeStack.Push(currentNode.rightChild);
                    }
                }
            }
            return dict;
        }
    }
}