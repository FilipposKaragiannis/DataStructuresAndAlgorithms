using System;
using System.Linq;
using Core.DataStructures;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests_DynamicArray
    {
        [SetUp]
        public void Setup()
        {
            _da = new DynamicArray<int>(5);
        }

        private DynamicArray<int> _da;

        [Test]
        [TestCase(0, 1)]
        [TestCase(1, 3)]
        [TestCase(2, 50)]
        [TestCase(4, 10999)]
        public void Set(int index, int value)
        {
            _da.Set(index, value);

            Assert.IsFalse(_da.IsEmpty());
            Assert.IsTrue(_da.Contains(value));
            Assert.AreEqual(value, _da.Get(index));
        }

        [Test]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(50)]
        [TestCase(10999)]
        public void Add(int value)
        {
            _da.Add(value);

            Assert.IsFalse(_da.IsEmpty());
            Assert.IsTrue(_da.Contains(value));
            Assert.AreEqual(value, _da.Get(_da.Size - 1));
        }

        [Test]
        [TestCase(1, 10)]
        [TestCase(0, 10)]
        [TestCase(4, 10)]
        public void Insert(int index, int value)
        {
            _da.Add(1);
            _da.Add(2);
            _da.Add(3);
            _da.Add(4);
            _da.Add(5);

            _da.Insert(index, value);

            Assert.AreEqual(value, _da.Get(index));
            Assert.AreEqual(_da.Size, 6);
            Assert.IsTrue(_da.Contains(value));
            CollectionAssert.Contains(_da, value);


            var expectedArray = new int[9];
            expectedArray[0] = 1;
            expectedArray[1] = 2;
            expectedArray[2] = 3;
            expectedArray[3] = 4;
            expectedArray[4] = 5;

            var expectedList = expectedArray.ToList();
            expectedList.Insert(index, value);
            CollectionAssert.AreEqual(expectedList.ToArray(), _da.ToArray());
        }

        [Test]
        [TestCase(1)]
        [TestCase(3)]
        public void Remove(int value)
        {
            _da.Add(4);
            _da.Add(5);
            _da.Add(6);
            _da.Add(value);

            var size = _da.Size;

            Assert.IsTrue(size > 0);

            _da.RemoveAt(size - 1);

            Assert.IsFalse(_da.Contains(value));
            Assert.AreEqual(size - 1, _da.Size);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(10)]
        [TestCase(6)]
        public void WhenTheIndexIsInvalid_AnExceptionIsThrown(int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() => _da.Get(index));
            Assert.Throws<IndexOutOfRangeException>(() => _da.Insert(index, 0));
            Assert.Throws<IndexOutOfRangeException>(() => _da.Set(index, 0));
            Assert.Throws<IndexOutOfRangeException>(() => _da.RemoveAt(index));

            Assert.AreEqual(_da.Size, 0);
        }
    }
}
