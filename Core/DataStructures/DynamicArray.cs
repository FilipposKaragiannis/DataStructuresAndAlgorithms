using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Core.DataStructures
{
    // Building a Dynamic array from scratch
    public class DynamicArray<T> : IEnumerable<T>
    {
        private T[] array;
        private int capacity;

        public DynamicArray(int capacity)
        {
            this.capacity = capacity;
            array         = new T[capacity];
            Size          = 0;
        }

        public int Size { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            return array.ToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T Get(int index)
        {
            if(index > capacity - 1 || index < 0)
                throw new IndexOutOfRangeException();

            return array[index];
        }

        public void Set(int index, T value)
        {
            if(index > capacity - 1 || index < 0)
                throw new IndexOutOfRangeException();

            array[index] = value;
            Size++;
        }

        public void Add(T value)
        {
            EnsureCapacity();

            array[Size++] = value;
        }

        public void Insert(int index, T value)
        {
            EnsureCapacity();

            Array.Copy(array, index, array, index + 1, Size - index);

            array[index] = value;
            Size++;
        }

        public void RemoveAt(int index)
        {
            if(index > capacity - 1 || index < 0)
                throw new IndexOutOfRangeException();

            Array.Copy(array, index + 1, array, index, Size - index);

            array[Size] = default;
            Size--;
        }

        public bool Contains(T value)
        {
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach(var a in array)
                if(value.Equals(a))
                    return true;

            return false;
        }

        public bool IsEmpty()
        {
            return Size == 0;
        }

        private void EnsureCapacity()
        {
            if(Size < capacity)
                return;

            capacity *= 2;
            var newArray = new T[capacity];

            Array.Copy(array, newArray, array.Length);

            array = newArray;
        }
    }
}
