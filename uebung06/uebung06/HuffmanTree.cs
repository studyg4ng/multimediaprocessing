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
    class HuffmanTree {
        public HuffmanNode root;

        public Dictionary<char, string> toDictionary() {
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
                        currentNode.leftChild.path = currentNode.path + '0';
                        nodeStack.Push(currentNode.leftChild);
                    }
                    if (currentNode.rightChild != null)
                    {
                        currentNode.rightChild.path = currentNode.path + '1';
                        nodeStack.Push(currentNode.rightChild);
                    }
                }
            }
            return dict;
        }
    }
}