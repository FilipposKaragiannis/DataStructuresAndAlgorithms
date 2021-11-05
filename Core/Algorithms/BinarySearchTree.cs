using System;

namespace Core.Algorithms
{
    public class BinarySearchTree
    {
        private Node root;

        public string Min()
        {
            return root.Min().value;
        }

        public void Delete(int key)
        {
            root = Delete(root, key);
        }

        private Node Delete(Node node, int key)
        {
            if(node == null)
                return null;

            if(key > node.key)
            {
                node.right = Delete(node.right, key);
            }
            else if(key < node.key)
            {
                node.left = Delete(node.left, key);
            }
            else // this is the node for deletion.
            {
                //case 1- no childer
                if(node.left == null && node.right == null)
                    return null;

                if(node.left == null)
                {
                    node = node.right;
                }
                else if(node.right == null)
                {
                    node = node.left;
                }
                else
                { //  2 children

                    // we need to find the min on the right, or the max on the left
                    var minRight = node.right.Min();
                    node.key   = minRight.key;
                    node.value = minRight.value;

                    node.right = Delete(node.right, minRight.key);
                }
            }

            return node;
        }

        public void Insert(int key, string value)
        {
            root = Insert(root, key, value);
        }

        private Node Insert(Node node, int key, string value)
        {
            // If node is null, we set it here and we are done!
            if(node == null)
            {
                node = new Node(key, value);
                return node;
            }

            // Walk until we find a node that is null, and set it there.
            // We follow the same logic here, comparing the node keys to define
            // which branch we need to follow.
            if(key > node.key)
                node.right = Insert(node.right, key, value);
            else if(key < node.key)
                node.left = Insert(node.left, key, value);


            // We have returned from the bottom, we are done. 
            // We now return the fully constructed tree!
            return node;
        }

        public string Find(int key)
        {
            var node = Find(root, key);

            return node?.value;
        }

        public void PostOrderTraversal()
        {
            PrintPostOrder(root);
        }

        private void PrintPostOrder(Node node)
        {
            if(node == null)
                return;

            PrintPostOrder(node.left);
            PrintPostOrder(node.right);
            Console.WriteLine($"{node.key}");
        }

        public void PrintPreOrderTraversal()
        {
            PreOrderPrint(root);
        }

        private void PreOrderPrint(Node node)
        {
            if(node == null)
                return;

            Console.WriteLine($"{node.key}");
            PreOrderPrint(node.left);
            PreOrderPrint(node.right);
        }

        public void PrintInOrderTraversal()
        {
            InOrderPrint(root);
        }

        private void InOrderPrint(Node node)
        {
            if(node == null)
                return;

            InOrderPrint(node.left);
            Console.WriteLine($"{node.key}");
            InOrderPrint(node.right);
        }

        // O(log(n)) where n is the size of the array. 
        private Node Find(Node node, int key)
        {
            if(node == null || node.key == key)
                return node;

            if(key > node.key)
                return Find(node.right, key);
            if(key < node.key)
                return Find(node.left, key);

            return null;
        }

        public void ConsolePrint()
        {
            root.Print();
        }

        public void Print()
        {
            var rootLeftKey  = root.left == null ? 0 : root.left.key;
            var rootRightKey = root.right == null ? 0 : root.right.key;

            var rootLeftLeftKey  = 0;
            var rootLeftRightKey = 0;

            if(root.left != null)
            {
                rootLeftLeftKey  = root.left.left == null ? 0 : root.left.left.key;
                rootLeftRightKey = root.left.right == null ? 0 : root.left.right.key;
            }

            var rootRightLeftKey  = 0;
            var rootRightRightKey = 0;

            if(root.right != null)
            {
                rootRightLeftKey  = root.right.left == null ? 0 : root.right.left.key;
                rootRightRightKey = root.right.right == null ? 0 : root.right.right.key;
            }

            Console.WriteLine("     " + root.key);
            Console.WriteLine("   /  \\");
            Console.WriteLine("  " + rootLeftKey + "    " + rootRightKey);
            Console.WriteLine(" / \\  / \\");
            Console.WriteLine(rootLeftLeftKey + "  " + rootLeftRightKey + " " + rootRightLeftKey + "   " + rootRightRightKey);
        }
    }

    public class Node
    {
        public int    key;
        public Node   left, right;
        public string value;

        public Node(int key, string value)
        {
            this.key   = key;
            this.value = value;
        }

        public Node Min()
        {
            return left == null ? this : left.Min();
        }
    }
}
