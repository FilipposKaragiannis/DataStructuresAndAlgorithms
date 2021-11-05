using System;

namespace Core.DataStructures
{
    public class Queue<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public void Enqueue(T value)
        {
            var newNode = new Node<T>(value);

            if(tail != null)
                tail.Next = newNode;

            tail =   newNode;
            head ??= tail;
        }

        public int Size()
        {
            if(head == null)
                return 0;

            var cur   = head;
            var count = 0;
            while(cur != null)
            {
                count++;
                cur = cur.Next;
            }

            return count;
        }

        public T Dequeue()
        {
            if(head == null)
                throw new IndexOutOfRangeException();

            var val = head.Value;
            head = head.Next;

            if(head == null)
                tail = null;

            return val;
        }

        public T Peek()
        {
            if(head == null)
                throw new IndexOutOfRangeException();

            return head.Value;
        }

        public bool IsEmpty()
        {
            return head == null;
        }
    }
}
