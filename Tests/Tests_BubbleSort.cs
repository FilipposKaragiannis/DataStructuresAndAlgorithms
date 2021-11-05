using Core;
using Core.Algorithms;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests_BubbleSort
    {
        private BubbleSort bs;

        [SetUp]
        public void Setup()
        {
            bs = new BubbleSort();
        }

        [Test]
        public void Sort()
        {
            int[] array = { 5, 4, 3, 2, 1 };

            var sorted = bs.Sort(array);
            
            sorted.Print();
            Assert.AreEqual(1, sorted[0]);
            Assert.AreEqual(2, sorted[1]);
            Assert.AreEqual(3, sorted[2]);
            Assert.AreEqual(4, sorted[3]);
            Assert.AreEqual(5, sorted[4]);
        }
    }
}
