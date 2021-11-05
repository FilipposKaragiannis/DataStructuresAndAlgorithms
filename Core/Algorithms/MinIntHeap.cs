using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Core.Algorithms
{
    public class MinIntHeap : IEnumerable<int>
    {
        private int[] array;
        private int   capacity = 15;

        public MinIntHeap()
        {
            array   = new int[capacity];
            GetSize = 0;
        }

        public int              GetSize                          { get; private set; }
        public IEnumerator<int> GetEnumerator()                  => array.ToList().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()                  => GetEnumerator();
        private static int      LeftChildIndex(int  parentIndex) => 2 * parentIndex + 1;
        private static int      RightChildIndex(int parentIndex) => 2 * parentIndex + 2;
        private static int      ParentIndex(int     childIndex)  => (childIndex - 1) / 2;
        private        int      GetParent(int       index)       => array[ParentIndex(index)];
        private        int      GetRightChild(int   index)       => array[RightChildIndex(index)];
        private        bool     HasParent(int       index)       => ParentIndex(index)     >= 0;
        private        bool     HasLeftChild(int    index)       => LeftChildIndex(index)  < GetSize;
        private        bool     HasRightChild(int   index)       => RightChildIndex(index) < GetSize;

        public void Insert(int value)
        {
            EnsureCapacity();
            array[GetSize++] = value;
            HeapifyUp();
        }

        private void HeapifyUp()
        {
            var index   = GetSize - 1;
            var element = array[index];

            while(HasParent(index) && GetParent(index) > element)
            {
                Swap(index, ParentIndex(index));
                index = ParentIndex(index);
            }
        }

        private void Swap(int l1, int l2) => (array[l1], array[l2]) = (array[l2], array[l1]);

        private void EnsureCapacity()
        {
            if(GetSize < capacity)
                return;

            capacity *= 2;
            var newArray = new int[capacity];
            Array.Copy(array, newArray, array.Length);
            array = newArray;
        }

        public int Peek() => array[0];

        public int ExtractMin()
        {
            var result = array[0];

            Swap(0, GetSize - 1);
            GetSize--;
            HeapifyDown();
            return result;
        }

        public void Print()
        {
            for(var i = 0; i < GetSize; i++)
                Console.WriteLine($"[ {array[i]} ]");
        }

        private void HeapifyDown()
        {
            if(GetSize <= 1)
                return;

            var index = 0;

            // We only need to check for left child because if there's no
            // left child we won't have a right
            while(HasLeftChild(index))
            {
                var smallChildIndex = LeftChildIndex(index);

                if(HasRightChild(index) && GetRightChild(index) < array[LeftChildIndex(index)])
                    smallChildIndex = RightChildIndex(index);


                if(array[index] < array[smallChildIndex])
                    break;

                Swap(index, smallChildIndex);
                index = smallChildIndex;
            }
        }
    }
}
