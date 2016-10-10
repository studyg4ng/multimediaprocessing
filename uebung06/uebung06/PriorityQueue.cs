using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uebung06
{
    class PriorityQueue<T> where T : IComparable
    {
        private List<T> arr = new List<T>();

        // returns the index of the parent node
        private static int ParentIdx(int idx)
        {
            return (idx - 1) / 2;
        }

        // returns the index of the left child
        private int LeftChildIdx(int idx)
        {
            return (2 * idx + 1);
            // What happens if no left child exists ?
        }

        // returns the index of the right child
        private static int RightChildIdx(int idx)
        {
            return (2 * idx + 2);
            // What happens if no right child exists ?
        }

        // get the largest element
        public T Front()
        {
            if (IsEmpty()) throw new InvalidOperationException(" Empty !");
            return arr[0];
        }

        public bool IsEmpty()
        {
            if (arr == null || arr.Count == 0) return true;
            return false;
        }

        public void Enqueue(T data)
        {
            arr.Add(data);
            // restore the heap , so that the
            // heap - condition is satisfied
            Upheap(GetLastIdx());
        }

        public int GetLastIdx()
        {
            return arr.Count - 1;
        }

        public void Swap(int idxA, int idxB)
        {
            T tmp = arr[idxA];
            arr[idxA] = arr[idxB];
            arr[idxB] = tmp;
        }

        public int Count()
        {
            return arr.Count;
        }

        // used for Enqueue () to restore the heap ,
        // so that the heap - condition is satisfied
        private void Upheap(int idx)
        {
            // swap if the parent is greater
            while (idx > 0 &&
           (arr[ParentIdx(idx)].CompareTo(arr[idx]) == 1))
            {
                Swap(ParentIdx(idx), idx);
                idx = ParentIdx(idx);
            }
        }

        public T Dequeue()
        {
            if (IsEmpty()) throw new InvalidOperationException("Empty!");

            //put  the  last  element  in the  beginning (root)
            T tmp = arr[0];
            arr[0] = arr[GetLastIdx()];

            // remove  the  old  last  element (which  is now  the  root)
            arr.RemoveAt(GetLastIdx());
            if (!IsEmpty()) Downheap(0);
            // restore  heap
            return tmp;
        }

        private void Downheap(int idx)
        {

            // while  not  already  at  bottom  level
            while (LeftChildIdx(idx) <= GetLastIdx())
            {

                //find  smaller  child
                int childIdx = LeftChildIdx(idx);
                if (RightChildIdx(idx) <= GetLastIdx() &&
                   arr[RightChildIdx(idx)].CompareTo(
                      arr[LeftChildIdx(idx)]) == -1)
                    childIdx = RightChildIdx(idx);

                // if the  child  is smaller , do the swap , otherwise  break
                if (arr[childIdx].CompareTo(arr[idx]) == -1)
                {
                    Swap(childIdx, idx);
                    idx = childIdx;
                }
                else break;
            }
        }    }
}

