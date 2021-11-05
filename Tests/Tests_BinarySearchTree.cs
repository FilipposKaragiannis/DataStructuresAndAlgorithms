using System;
using Core.Algorithms;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests_BinarySearchTree
    {
        [SetUp]
        public void Setup()
        {
            bst = new BinarySearchTree();
        }

        private BinarySearchTree bst;


        [Test]
        public void Insert()
        {
            bst.Insert(5, "e");
            bst.Insert(3, "c");
            bst.Insert(2, "b");
            bst.Insert(4, "d");
            bst.Insert(7, "g");
            bst.Insert(6, "f");
            bst.Insert(8, "h");

            Assert.AreEqual("e", bst.Find(5));
            Assert.AreEqual("c", bst.Find(3));
            Assert.AreEqual("b", bst.Find(2));
            Assert.AreEqual("d", bst.Find(4));
            Assert.AreEqual("g", bst.Find(7));
            Assert.AreEqual("f", bst.Find(6));
            Assert.AreEqual("h", bst.Find(8));
            Assert.AreEqual(null, bst.Find(99));

            bst.Print();

            Console.WriteLine("In order : \n");

            bst.PrintInOrderTraversal();
            Console.WriteLine("Pre order : \n");
            bst.PrintPreOrderTraversal();
            Console.WriteLine("Post order: \n");
            bst.PostOrderTraversal();
        }

        [Test]
        public void Min()
        {
            bst.Insert(5, "e");
            bst.Insert(3, "c");
            bst.Insert(2, "b");

            Assert.AreEqual("b", bst.Min());
        }

        [Test]
        public void DeleteNoChild()
        {
            bst.Insert(5, "e");
            bst.Insert(3, "c");
            bst.Insert(2, "b");
            bst.Insert(4, "d");
            bst.Insert(7, "g");
            bst.Insert(6, "f");
            bst.Insert(8, "h");

            bst.Delete(2);

            Assert.IsNull(bst.Find(2));

            bst.Print();
        }

        [Test]
        public void DeleteOneChild()
        {
            bst.Insert(5, "e");
            bst.Insert(3, "c");
            bst.Insert(2, "b");
            bst.Insert(4, "d");
            bst.Insert(7, "g");
            bst.Insert(8, "h");

            bst.Delete(7);

            Assert.IsNull(bst.Find(7));
            bst.Print();
        }

        [Test]
        public void DeleteTwoChildren()
        {
            bst.Insert(5, "e");
            bst.Insert(3, "c");
            bst.Insert(2, "b");
            bst.Insert(4, "d");
            bst.Insert(7, "g");
            bst.Insert(6, "f");
            bst.Insert(8, "h");

            bst.Delete(7);

            Assert.IsNull(bst.Find(7));

            bst.Print();
        }
    }
}
