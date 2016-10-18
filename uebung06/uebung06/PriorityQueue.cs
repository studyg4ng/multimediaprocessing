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

namespace uebung06 {
    class PriorityQueue<T> where T : IComparable {
        private List<T> arr = new List<T>();

        private static int getParentIdx(int idx) {
            return (idx - 1) / 2;
        }

        private static int getLeftChildIdx(int idx) {
            return (2 * idx + 1);
        }

        private static int getRightChildIdx(int idx) {
            return (2 * idx + 2);
        }

        public T First() {
            if (IsEmpty()) throw new InvalidOperationException(" Empty !");
            return arr[0];
        }

        public bool IsEmpty() {
            if (arr == null || arr.Count == 0) return true;
            return false;
        }

        public void Enqueue(T data) {
            arr.Add(data);
            Upheap(GetLastIdx()); // restore heap
        }

        public int GetLastIdx() {
            return arr.Count - 1;
        }

        public void Swap(int idxA, int idxB) {
            T tmp = arr[idxA];
            arr[idxA] = arr[idxB];
            arr[idxB] = tmp;
        }

        public int Count() {
            return arr.Count;
        }

        private void Upheap(int idx) {
            while (idx > 0 &&
           (arr[getParentIdx(idx)].CompareTo(arr[idx]) == 1)) // swap if the parent is greater
            {
                Swap(getParentIdx(idx), idx);
                idx = getParentIdx(idx);
            }
        }

        public T Dequeue() {
            if (IsEmpty()) throw new InvalidOperationException("Empty!");

            T tmp = arr[0]; // set last element as root
            arr[0] = arr[GetLastIdx()];

            arr.RemoveAt(GetLastIdx()); // remove last element (now root)
            if (!IsEmpty()) Downheap(0); // restore heap
            return tmp;
        }

        private void Downheap(int idx) {
            while (getLeftChildIdx(idx) <= GetLastIdx()) // while not at bottom level
            {
                //find  smaller  child
                int childIdx = getLeftChildIdx(idx);
                if (getRightChildIdx(idx) <= GetLastIdx() &&
                    arr[getRightChildIdx(idx)].CompareTo(arr[getLeftChildIdx(idx)]) == -1)
                    childIdx = getRightChildIdx(idx); // set child

                if (arr[childIdx].CompareTo(arr[idx]) == -1) // swap if the child is smaller
                {
                    Swap(childIdx, idx);
                    idx = childIdx;
                }
                else break;
            }
        }
    }
}