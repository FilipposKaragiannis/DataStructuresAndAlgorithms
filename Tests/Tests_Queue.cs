using System;
using Core.DataStructures;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests_Queue
    {
        [SetUp]
        public void Setup()
        {
            queue = new Queue<string>();
        }

        private Queue<string> queue;

        [Test]
        public void Enqueue()
        {
            queue.Enqueue("a");
            queue.Enqueue("b");
            queue.Enqueue("c");

            Assert.AreEqual(3, queue.Size());
            Assert.AreEqual("a", queue.Peek());
            Assert.IsFalse(queue.IsEmpty());
        }

        [Test]
        public void Dequeue()
        {
            queue.Enqueue("a");
            queue.Enqueue("b");
            queue.Enqueue("c");

            Assert.AreEqual("a", queue.Dequeue());
            Assert.AreEqual("b", queue.Peek());
            Assert.AreEqual(2, queue.Size());
        }

        [Test]
        public void Peek()
        {
            queue.Enqueue("a");
            queue.Enqueue("b");
            queue.Enqueue("c");

            Assert.AreEqual("a", queue.Peek());
            Assert.AreEqual(3, queue.Size());
        }

        [Test]
        public void WhenEmpty_ThrowsException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => queue.Dequeue());
            Assert.Throws<IndexOutOfRangeException>(() => queue.Peek());
        }
    }
}
