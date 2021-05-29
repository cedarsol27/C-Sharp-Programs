using System;
using static System.Console;

namespace BinarySearchTree
{
    public class BinarySearchTree // creating a class
    {
        public class Node
        {
            public int data;

            public Node left, right;

            public Node(int data) // this is a contructor
            {
                this.data = data;
            }

            public void Insert(int value)
            {
                if (value <= data)
                {
                    if (left == null)
                        left = new Node(value);
                    else
                        left.Insert(value);
                }
                else
                {
                    if (right == null)
                        right = new Node(value);
                    else
                        right.Insert(value);
                }
            }

            public bool Contains(int value)
            {
                if (value == data)
                {
                    return true;
                }
                else if (value < data)
                {
                    if (left == null) { return false; }
                    else
                        return left.Contains(value);
                }
                else
                {
                    if (right == null) { return false; }
                    else { return right.Contains(value); }
                }
            }

            public object Min(Node root)
            {
                Node current = new Node(data);
                current = root;
                if (current.left == null)
                {
                    WriteLine(current.data);
                    return current.data;
                }
                return Min(current.left);
            }

            public object Max(Node root)
            {
                Node current = new Node(data);
                current = root;
                if (current.right == null)
                {
                    WriteLine(current.data);
                    return current.data;
                }
                return Max(current.right);
            }

            public void Preorder()
            {
                WriteLine(data);
                if (left != null)
                    left.Preorder();
                if (right != null)
                    right.Preorder();
            }

            public void Inorder()
            {
                if (left != null)
                    left.Inorder();
                WriteLine(data);
                if (right != null)
                    right.Inorder();
            }

            public void Postorder()
            {
                if (left != null)
                    left.Postorder();
                if (right != null)
                    right.Postorder();
                WriteLine(data);
            }

            public Node DeleteRec(Node root, int i)
            {
                if (root == null)
                    return root;
                if (i < root.data)
                    root.left = DeleteRec(root.left, i);
                else if (i > root.data)
                    root.right = DeleteRec(root.right, i);
                else
                {
                    if (root.left == null)
                        return root.right;
                    else if (root.right == null)
                        return root.left;
                    Min(root.right);
                    root.right = DeleteRec(root.right, root.data);
                }
                return root;
            }
        }

        public Node root; // class-level Node root

        public BinarySearchTree() // constructing an instance of the class
        {
            root = null;
        }

        public void Insert(int i)
        {
            if (root == null)
                root = new Node(i);
            else
                root.Insert(i);
        }

        public void Contains(int i)
        {
            bool? confirm = null;
            if (root != null)
                confirm = root.Contains(i);
            if (confirm == true)
                WriteLine("Entry has been found.");
            else
                WriteLine("Entry is not found.");
        }

        public void Minimum()
        {
            if (root != null)
                root.Min(root);
        }

        public void Maximum()
        {
            if (root != null)
                root.Max(root);
        }

        public void Preorder()
        {
            if (root != null)
                root.Preorder();
        }

        public void Inorder() // Instance calls the methods within the node class above
        {
            if (root != null)
                root.Inorder();
        }

        public void Postorder()
        {
            if (root != null)
                root.Postorder();
        }

        public void Delete(int i)
        {
            if (root != null)
                root.DeleteRec(root, i);
        }
    }
    class MainClass
    {
        public static void Main()
        {
            BinarySearchTree tree = new BinarySearchTree();

            Random r = new Random();

            WriteLine("Welcome! The purpose of this program is to generate numbers randomly " +
                "\nand use a binary search tree to sort and find any given number.");
            string userInput = ReadLine();
            for (int index = 0; index < 13; index++)
            {
                int generated = r.Next(0, 100);
                tree.Insert(generated);
            }

            Write("Would you like to traverse in-order? \"No\" skips. ");
            userInput = ReadLine();

            if (!string.Equals(userInput, "No", StringComparison.OrdinalIgnoreCase))
                tree.Inorder();

            Write("Would you like to traverse pre-order? \"No\" skips. ");
            userInput = ReadLine();

            if (!string.Equals(userInput, "No", StringComparison.OrdinalIgnoreCase))
                tree.Preorder();

            Write("Would you like to traverse post-order? \"No\" skips. ");
            userInput = ReadLine();

            if (!string.Equals(userInput, "No", StringComparison.OrdinalIgnoreCase))
                tree.Postorder();

            Write("Would you like to print the smallest number? \"No\" skips. ");
            userInput = ReadLine();

            if (!string.Equals(userInput, "No", StringComparison.OrdinalIgnoreCase))
                tree.Minimum();

            Write("Would you like to print the largest number? \"No\" skips. ");
            userInput = ReadLine();

            if (!string.Equals(userInput, "No", StringComparison.OrdinalIgnoreCase))
                tree.Maximum();

            Write("Would you like to search for a particular number? \"Yes\" continues. ");
            userInput = ReadLine();

            if (string.Equals(userInput, "Yes", StringComparison.OrdinalIgnoreCase))
            {
                Write("Please enter a number to search for: ");
                int number = int.Parse(ReadLine());
                tree.Contains(number);
            }

            Write("Would you like to delete a particular number? \"Yes\" continues. ");
            userInput = ReadLine();

            if (string.Equals(userInput, "Yes", StringComparison.OrdinalIgnoreCase))
            {
                Write("Please enter a number to delete: ");
                int number = int.Parse(ReadLine());
                tree.Delete(number);
            }

            tree.Inorder();
        }
    }
}
