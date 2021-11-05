using Core.Algorithms;

namespace Playground
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var bst = new BinarySearchTree();

            bst.Insert(5, "e");
            bst.Insert(3, "c");
            bst.Insert(2, "b");
            bst.Insert(4, "d");
            bst.Insert(7, "g");
            bst.Insert(6, "f");
            bst.Insert(8, "h");

            bst.Delete(7);

            bst.ConsolePrint();
        }
    }
}
