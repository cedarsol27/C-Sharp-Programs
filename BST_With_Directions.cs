using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;


namespace BST
{
    public class BinarySearchTree // create new class
    {
        public class Node // 5.1. create new class of a node
        {
            public int data; // 5.2 create parent node
            public Node left; // create child node, sibling of right
            public Node right; // create child node, sibling of left
            public Node(int data)
            {
                this.data = data;
            }
            public void Print()
            {
                if (left != null)
                    left.Print();
                WriteLine(data);
                if (right != null)
                    right.Print();
            }
            
        }


        public Node root; // root node is created
        public BinarySearchTree() // 2. Create new BST
        {
            root = null; // root is created, empty value
        }

        public void Print()
        {
            if (root != null)
                root.Print();
        }
            Node newNode = new Node(); // 4. create Node newNode
                                      // 8. create Node newNode
                                      // 21. create Node NewNode

            newNode.data = i; // 5. data from 3 goes into data of newNode
                             // 9. data from 7 goes into data of newNode, children null
                             // 22. date from 20 ...

            if (root == null) // 6a. if the head/root node is empty (from step 2)
                             // 10. willnot be true, as node is now created
                             // 23. not true

               root = newNode; // 6a.1 newNode.data is passed, including build of Node (left and right)

            else
            {
               Node current = root; // 11. value of root is copied into Node current, including null children
                                    // 24. See step 11, also note right node has a value from step 7

               Node parent; // 12. undefined parent value
                            // 25. another undefined parent value

               while (true) // 13. stays true
                            // 26. keeps running until a break occurs
               {
                   parent = current; // 14. value of current (root) passed into parent, including children
                                     // 27. value of current (root) passed into parent, including step 7
                                     // 31. value of current passed into parent

                   if (current == null) // 15. if current is null, which it should not be...
                                        // 28. is not
                                        // 32. is not
                   {
                       parent.left = newNode; // 15a. value of step nine is placed into left node
                       break;
                   }
                   else
                   {
                       current = current.right; // 16. null value of current.right put into current
                                                // 29. data of right passed to current
                                                // 33. null value of current.right passed into current.data

                       if (current == null) // 17. true because current is now null
                                            // 30. false because current has data from step 7
                                            // 34. true
                       {
                           parent.right = newNode; // 18. newNode value and children passed to the right node
                                                   // 35. right node of parent is now passed a value
                           break; // 19. break out of while loop
                       }
                   }                   // begin while statement because static true
               }
            }
        }


    }

    class MainClass
    {
        public static void Main()
        {
            BinarySearchTree tree = new BinarySearchTree(); // 1. Create new Binary Tree
            tree.Insert(50); // 3. insert number into tree
            tree.Insert(17); // 7. insert next number into tree
            tree.Insert(23); // 20. insert next number into tree
            tree.Insert(12);
            tree.Insert(19);
            tree.Insert(54);
            tree.Insert(9);
            tree.Insert(14);
            tree.Insert(67);
            tree.Insert(76);
            tree.Insert(72);
            tree.Print();
        }
    }
}
