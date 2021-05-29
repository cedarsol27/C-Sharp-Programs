using System;

namespace AVLTrees_v1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            AVLTrees_v1<int> tree = new AVLTree<int>();
            for (int i = 1; i < 10; i++)
            {
                tree.Add(i);
            }
            Console.WriteLine("In Order: " + string.Join(", ", tree.GetInorderEnumerator()));
            Console.WriteLine("Post Order: " + string.Join(", ", tree.GetPostorderEnumerator()));
            Console.WriteLine("Breadth-first: " + string.Join(", ", tree.GetBreadthFirstEnumerator()));

            AVLTreeNode<int> node = tree.FindNode(8);
            Console.WriteLine($"Children of node {node.Value} (height = {node.Height}): {node.Left.Value} and {node.Right.Value}.");
        }
    }
}
