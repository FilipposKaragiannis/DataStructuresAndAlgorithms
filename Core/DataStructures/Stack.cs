using System;

namespace Core.DataStructures
{
    public class Stack<T>
    {
        private Node<T> head;

        public void Push(T value)
        {
            var newNode = new Node<T>(value);

            if(head == null)
            {
                head = newNode;
                return;
            }

            newNode.Next = head;
            head         = newNode;
        }

        public T Pop()
        {
            if(head == null)
                throw new IndexOutOfRangeException();

            var value = head.Value;

            head = head.Next;

            return value;
        }

        // This is currently O(N) but we can improve to constant time if we store 
        // size as a field and update it with push/pop
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
