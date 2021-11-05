using System.Linq;
using Core.Algorithms;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests_MaxIntHeap
    {
        [SetUp]
        public void Setup()
        {
            maxHeap = new MaxIntHeap();
        }

        private MaxIntHeap maxHeap;


        [Test]
        public void ExtractMax()
        {
            maxHeap.Insert(42);
            maxHeap.Insert(18);
            maxHeap.Insert(29);
            maxHeap.Insert(35);

            var expected = new int[15];
            expected[0] = 42;
            expected[1] = 35;
            expected[2] = 29;
            expected[3] = 18;

            CollectionAssert.AreEqual(expected, maxHeap.ToArray());
            Assert.AreEqual(4, maxHeap.GetSize);
        }

        [Test]
        public void PeekMax()
        {
            maxHeap.Insert(18);
            maxHeap.Insert(29);
            maxHeap.Insert(35);
            
            Assert.AreEqual(35, maxHeap.Peek());
        }

        [Test]
        public void Insert()
        {
            maxHeap.Insert(42);
            maxHeap.Insert(29);
            maxHeap.Insert(18);
            maxHeap.Insert(14);
            maxHeap.Insert(7);
            maxHeap.Insert(18);
            maxHeap.Insert(12);
            maxHeap.Insert(11);
            maxHeap.Insert(13);

            Assert.AreEqual(9, maxHeap.GetSize);

            maxHeap.Print();
            Assert.AreEqual(42, maxHeap.ExtractMax());
            Assert.AreEqual(29, maxHeap.ExtractMax());
            Assert.AreEqual(18, maxHeap.ExtractMax());
            Assert.AreEqual(18, maxHeap.ExtractMax());
            Assert.AreEqual(14, maxHeap.ExtractMax());
            Assert.AreEqual(13, maxHeap.ExtractMax());
            Assert.AreEqual(12, maxHeap.ExtractMax());
            Assert.AreEqual(11, maxHeap.ExtractMax());
            Assert.AreEqual(7, maxHeap.ExtractMax());
            Assert.AreEqual(0, maxHeap.GetSize);
            maxHeap.Print();
        }
    }
}
