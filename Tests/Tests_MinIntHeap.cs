using System.Linq;
using Core.Algorithms;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests_MinIntHeap
    {
        [SetUp]
        public void Setup()
        {
            minHeap = new MinIntHeap();
        }

        private MinIntHeap minHeap;


        [Test]
        public void ExtractMin()
        {
            minHeap.Insert(42);
            minHeap.Insert(18);
            minHeap.Insert(29);
            minHeap.Insert(35);

            var expected = new int[15];
            expected[3] = 42;
            expected[2] = 29;
            expected[1] = 35;
            expected[0] = 18;

            minHeap.Print();
            CollectionAssert.AreEqual(expected, minHeap.ToArray());
            Assert.AreEqual(4, minHeap.GetSize);
        }

        [Test]
        public void PeekMin()
        {
            minHeap.Insert(18);
            minHeap.Insert(29);
            minHeap.Insert(7);
            minHeap.Insert(35);
            
            Assert.AreEqual(7, minHeap.Peek());
        }

        [Test]
        public void Insert()
        {
            minHeap.Insert(42);
            minHeap.Insert(29);
            minHeap.Insert(18);
            minHeap.Insert(14);
            minHeap.Insert(7);
            minHeap.Insert(18);
            minHeap.Insert(12);
            minHeap.Insert(11);
            minHeap.Insert(13);

            Assert.AreEqual(9, minHeap.GetSize);

            minHeap.Print();
            Assert.AreEqual(7, minHeap.ExtractMin());
            Assert.AreEqual(11, minHeap.ExtractMin());
            Assert.AreEqual(12, minHeap.ExtractMin());
            Assert.AreEqual(13, minHeap.ExtractMin());
            Assert.AreEqual(14, minHeap.ExtractMin());
            Assert.AreEqual(18, minHeap.ExtractMin());
            Assert.AreEqual(18, minHeap.ExtractMin());
            Assert.AreEqual(29, minHeap.ExtractMin());
            Assert.AreEqual(42, minHeap.ExtractMin());
            Assert.AreEqual(0, minHeap.GetSize);
            minHeap.Print();
        }
    }
}
