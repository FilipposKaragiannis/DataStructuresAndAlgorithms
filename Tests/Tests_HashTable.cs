using Core.DataStructures;
using NUnit.Framework;

namespace Tests
{
    public class Tests_HashTable
    {
        private HashTable hashTable;

        [SetUp]
        public void Setup()
        {
            hashTable = new HashTable();
        }


        [Test]
        public void PutAndGet()
        {
            hashTable.Put("John Smith", "521-1234");
            hashTable.Put("Lisa Smith", "521-8976");
            hashTable.Put("Sam Doe", "521-5030");
            hashTable.Put("Sandra Dee", "521-9655");
            hashTable.Put("Ted Baker", "418-4165");

            Assert.AreEqual("521-1234", hashTable.Get("John Smith"));
            Assert.AreEqual("521-8976", hashTable.Get("Lisa Smith"));
            Assert.AreEqual("521-5030", hashTable.Get("Sam Doe"));
            Assert.AreEqual("521-9655", hashTable.Get("Sandra Dee"));
            Assert.AreEqual("418-4165", hashTable.Get("Ted Baker"));
            Assert.AreEqual(null, hashTable.Get("Tim Lee"));
        }

        [Test]
        public void Collision()
        {
            // these keys will collide
            hashTable.Put("John Smith", "521-1234");
            hashTable.Put("Sandra Dee", "521-9655");

            Assert.AreEqual("521-1234", hashTable.Get("John Smith"));
            Assert.AreEqual("521-9655", hashTable.Get("Sandra Dee"));
            Assert.AreEqual(null, hashTable.Get("Tim Lee"));
        }
    }
}
