using Core.DataStructures;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests_LinkedList
    {
        [SetUp]
        public void Setup()
        {
            linkedList = new SingleLinkedList<int>();
        }

        private SingleLinkedList<int> linkedList;

        [Test]
        public void AddFront()
        {
            linkedList.AddFront(1);
            linkedList.AddFront(3);
            linkedList.AddFront(2);

            Assert.AreEqual(3, linkedList.Size);
            Assert.AreEqual(2, linkedList.GetFirst());
            Assert.AreEqual(1, linkedList.GetLast());

            linkedList.Print();
        }

        [Test]
        public void AddBack()
        {
            linkedList.AddBack(1);
            linkedList.AddBack(3);
            linkedList.AddBack(2);

            Assert.AreEqual(3, linkedList.Size);
            Assert.AreEqual(1, linkedList.GetFirst());
            Assert.AreEqual(2, linkedList.GetLast());

            linkedList.Print();
        }

        [Test]
        public void Size()
        {
            Assert.AreEqual(0, linkedList.Size);

            linkedList.AddBack(1);
            Assert.AreEqual(1, linkedList.Size);
            linkedList.AddFront(2);

            Assert.AreEqual(2, linkedList.Size);
        }

        [Test]
        public void Clear()
        {
            linkedList.AddBack(1);
            linkedList.AddBack(3);
            linkedList.AddBack(2);

            linkedList.Clear();

            Assert.AreEqual(0, linkedList.Size);
            Assert.AreEqual(default(int), linkedList.GetFirst());
        }


        [Test]
        public void GetFirst()
        {
            linkedList.AddFront(2);

            Assert.AreEqual(2, linkedList.GetFirst());

            linkedList.Print();
        }

        [Test]
        public void Contains()
        {
            linkedList.AddBack(3);
            linkedList.AddBack(2);

            Assert.IsTrue(linkedList.Contains(3));
            Assert.IsTrue(linkedList.Contains(2));
            Assert.IsFalse(linkedList.Contains(1));
        }

        [Test]
        public void DeleteValue()
        {
            linkedList.AddBack(1);
            linkedList.AddBack(3);
            linkedList.AddBack(2);

            linkedList.Delete(3);


            Assert.AreEqual(1, linkedList.GetFirst());
            Assert.AreEqual(2, linkedList.Size);
            Assert.IsFalse(linkedList.Contains(3));
        }


        [Test]
        public void DeleteLastValue()
        {
            linkedList.AddBack(1);
            linkedList.AddBack(3);
            linkedList.AddBack(2);

            linkedList.DeleteLast();


            Assert.AreEqual(3, linkedList.GetLast());
            Assert.IsFalse(linkedList.Contains(2));
            Assert.AreEqual(2, linkedList.Size);
        }

        [Test]
        public void DeleteFrontValue()
        {
            linkedList.AddFront(1);
            linkedList.AddBack(3);
            linkedList.AddBack(2);

            linkedList.DeleteFront();


            Assert.AreEqual(3, linkedList.GetFirst());
            Assert.IsFalse(linkedList.Contains(1));
            Assert.AreEqual(2, linkedList.Size);
        }


        [Test]
        public void GetLast()
        {
            linkedList.AddFront(10);
            linkedList.AddFront(20);
            linkedList.AddFront(454);

            Assert.AreEqual(10, linkedList.GetLast());

            linkedList.Print();
        }
    }
}
