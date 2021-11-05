using System;
using System.Text;

namespace Core.DataStructures
{
    public class SingleLinkedList<T>
    {
        private Node<T> head;

        public SingleLinkedList(params T[] values)
        {
            foreach(var v in values)
                AddBack(v);
        }

        public SingleLinkedList(T value)
        {
            head = new Node<T>(value);
            Size = 1;
        }

        public SingleLinkedList()
        {
            Size = 0;
            head = null;
        }

        public int Size { get; private set; }

        public void AddFront(T value)
        {
            if(head == null)
            {
                head = new Node<T>(value);
                Size++;
                return;
            }

            var newHead = new Node<T>(value);
            newHead.Next = head;
            head         = newHead;
            Size++;
        }

        public T GetFirst()
        {
            return head != null ? head.Value : default;
        }

        public T GetLast()
        {
            if(head == null)
                return default;

            var curr = head;
            while(curr.Next != null)
                curr = curr.Next;

            return curr.Value;
        }

        public void AddBack(T value)
        {
            if(head == null)
            {
                head = new Node<T>(value);
                Size++;
                return;
            }

            var curr = head;
            while(curr.Next != null)
                curr = curr.Next;

            var newNode = new Node<T>(value);
            curr.Next = newNode;
            Size++;
        }

        public void Print()
        {
            var sb  = new StringBuilder();
            var cur = head;
            while(true)
            {
                if(cur == null)
                {
                    sb.Append("null");
                    break;
                }

                sb.Append($"{cur.Value} -> ");
                cur = cur.Next;
            }

            Console.WriteLine(sb.ToString());
        }

        public void Clear()
        {
            head = null;
            Size = 0;
        }

        public bool Contains(T value)
        {
            if(head == null)
                return false;

            var cur = head;

            while(cur != null)
            {
                if(cur.Value.Equals(value))
                    return true;

                cur = cur.Next;
            }

            return false;
        }

        public void Delete(int value)
        {
            if(head == null)
                return;

            if(head.Value.Equals(value))
            {
                DeleteFront();
                return;
            }

            var cur = head;

            while(cur.Next != null)
            {
                if(cur.Next.Value.Equals(value))
                {
                    cur.Next = cur.Next.Next;
                    Size--;
                    return;
                }

                cur = cur.Next;
            }

            throw new MissingMemberException();
        }

        public void DeleteLast()
        {
            if(head == null)
                return;


            if(head.Next == null)
            {
                head = null;
                Size = 0;
                return;
            }

            var cur  = head;
            var next = cur.Next;
            while(next != null)
            {
                if(next.Next == null)
                {
                    cur.Next = null;
                    Size--;
                    return;
                }

                cur  = next;
                next = next.Next;
            }
        }

        public void DeleteFront()
        {
            if(head == null)
                return;

            head = head.Next;
            Size--;
        }
    }
}
