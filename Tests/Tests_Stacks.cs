using System;
using Core.DataStructures;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests_Stacks
    {
        [SetUp]
        public void Setup()
        {
            stack = new Stack<string>();
        }

        private Stack<string> stack;

        [Test]
        public void Push()
        {
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            Assert.AreEqual(3, stack.Size());
            Assert.AreEqual("c", stack.Peek());
            Assert.IsFalse(stack.IsEmpty());
        }

        [Test]
        public void Pop()
        {
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            Assert.AreEqual("c", stack.Pop());
            Assert.AreEqual("b", stack.Peek());
            Assert.AreEqual(2, stack.Size());
        }

        [Test]
        public void Peek()
        {
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            Assert.AreEqual("c", stack.Peek());
            Assert.AreEqual(3, stack.Size());
        }

        [Test]
        public void WhenEmpty_ThrowsException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => stack.Peek());
            Assert.Throws<IndexOutOfRangeException>(() => stack.Pop());
        }
    }
}
