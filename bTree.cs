using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


// Source code from: https://www.programiz.com/dsa/b-tree, https://www.programiz.com/dsa/deletion-from-a-b-tree

namespace bTree
{
    class MainClass
    {

        public class Btree // the class that contains the node itself
        {
            public BTreeNode root;
            public int t;
            public Btree(int t) // Create new bTree
            {
                root = null; // assign root to null
                this.t = t; // max degree of children per node
            }
            public void Traverse()
            {
                if (root != null) // if the root is not null, traverse it
                {
                    root.Traverse(root);
                }
                WriteLine();
            }
            public BTreeNode Search(int target)
            {
                if (root == null) // if the bTree is empty, return null
                {
                    return null;
                }
                else
                {
                    return root.Search(root, target); //otherwise start the search at the root
                }
            }
            public void Insert(int target, object payee, object debit)
            {
                if (root == null) // if root is null, only for constructing the first time
                {
                    root = new BTreeNode(t, true, payee, debit); // create a new treenode 
                    root.keys[0] = target; // index 0 has value target

                    root.n = 1; // One key now exists in this node
                }
                else // if the tree has at least one value
                {
                    if (root.n == 2 * t - 1) // if the r is full, add new node and split
                    {
                        BTreeNode r = root; // copy root to r
                        BTreeNode a = new BTreeNode(t, false, payee, debit); // creates a new parent node, assigns as false for leaf
                        root = a; // root is now blank
                        a.Child[0] = r; // set the first child [0] of the new root node as the old root node
                        a.Split_Child(0, r); // split the old root node and move 1 key to the new root node

                        int i = 0;
                        if (a.keys[0] < target) { i++; } // move through array to find target and enter
                        a.Child[i].InsertAfterSplit(a, target);
                    }
                    else
                    {
                        root.InsertNextValue(root, target, payee); // if the root is not full, use InsertNextValue method
                    }
                }
            }
            public void Remove(int target)
            {
                if (root != null) // ensure there's something to remove
                {
                    root.Remove(root, target);
                }
            }

        }
        public class BTreeNode
        {
            public int[] keys; // the array for keys
            public int t; // the minimum degree of the BTree, this could be larger for loading large data
            public BTreeNode[] Child; // the array of children nodes
            public int n; // the number of keys in this node
            public bool leaf; // a boolean if this node is a leaf
            public object payee;
            public object debit;
            public BTreeNode(int t, bool leaf, object payee, object debit)// constructor for BTreeNode
            {
                this.t = t; // BTreeNode.t, assigns the maximum amount of children per node, universal
                this.leaf = leaf; // BTreeNode.Leaf, default true
                this.keys = new int[2 * t - 1]; // the maximum number of keys must be 1 less than 2 times the min degree
                this.Child = new BTreeNode[2 * t]; // the maximum number of children nodes is 2 times the min degree
                this.n = 0; // The number of keys in a new node, set to 0
                this.payee = payee;
                this.debit = debit;
            }
            public int Find(int target) // this is used to identify the target value in specificed node
            {
                for (int i = 0; i < this.n; i++)
                {
                    if (this.keys[i] == target) // searches through each n index to find value
                    {
                        return i; // return 1
                    }
                }
                return -1; // otherwises returns -1
            }


            public void Traverse(BTreeNode x)
            {
                int i;
                for (i = 0; i < n; i++) // increment through each index the node starting at 0
                {
                    if (!leaf) // if this node is not a leaf then call the traverse method on it's lower child
                    {
                        Child[i].Traverse(x);
                    }
                    Write(keys[i] + "    "); // print out value in lowest value
                    Write(payee + "    ");
                    Write(debit + "    \n");
                }
                if (!leaf) // keep traversing through children until a leaf is hit
                {
                    Child[i].Traverse(x);
                }
            }
            public BTreeNode Search(BTreeNode x, int target)
            {
                int i = 0;
                if (x == null)
                    return x;
                for (i = 0; i < x.n; i++)
                {
                    if (target < x.keys[i]) { break; }
                    if (target == x.keys[i]) { return x; }
                }
                if (x.leaf) { return null; }
                else { return Search(x.Child[i], target); }
            }
            public void InsertNextValue(BTreeNode root, int target, object payee)
            {
                int i = 0; // counter for index movement
                if (leaf) // if this node is a leaf
                {
                    for (i = root.n - 1; i >= 0 && target < root.keys[i]; i--) // ensure that target is greater than current value, and not in index less than 0
                    {
                        root.keys[i + 1] = root.keys[i]; // copy value into array up one sloty
                    }
                    keys[i + 1] = target; // insert target into cleared index
                    n++; // increase active index slot
                }
                else
                {
                    for (i = root.n - 1; i >= 0 && target < root.keys[i]; i--) { }
                    ;
                    i++;
                    BTreeNode temp = root.Child[i];
                    if (temp.n == 2 * t - 1)
                    {
                        Split_Child(i, temp);
                        if (target > root.keys[i]) { i++; }
                    }
                    InsertAfterSplit(root.Child[i], target);
                }
            }

            public void Split_Child(int j, BTreeNode rootNode)
            {
                BTreeNode c = new BTreeNode(t, rootNode.leaf, payee, debit);// create a new child node to store the lower keys of rootNode, which will be split
                c.n = t - 1; // this splits up the values and indices
                for (int i = 0; i < t - 1; i++) // copy the lower keys of root to the new node c
                {
                    c.keys[i] = rootNode.keys[i + t]; // copys values, but with t leading
                }

                if (!rootNode.leaf) // if rootNode has children copy the last t children of node b to node c
                {
                    for (int i = 0; i < t; i++)
                    {
                        c.Child[i] = rootNode.Child[i + t]; // place rootNode children into c children
                    }
                }
                rootNode.n = t - 1; // assign key counter to t - 1

                for (int i = n; i >= j + 1; i--) // shift data in children
                {
                    Child[i + 1] = Child[i];
                }
                Child[j + 1] = c; // copy over split data
                for (int i = n - 1; i >= j; i--)
                {
                    keys[i + 1] = keys[i]; // move data in keys
                }
                keys[j] = rootNode.keys[t - 1]; // copy index rootNode.keys into childNode
                n++; // increase index
            }

            public void InsertAfterSplit(BTreeNode root, int target)
            {
                int i = n - 1; // counter for index movement
                if (leaf) // if this node is a leaf
                {
                    while (i >= 0 && keys[i] > target)
                    {
                        keys[i + 1] = keys[i]; // insert target into cleared index
                        i--;
                    }
                    keys[i + 1] = target;
                    n++; // increase active index slot
                }
                else
                {
                    while (i >= 0 && keys[i] > target) // if not a leaf, split to insert in non-full array
                    { i--; }
                    if (Child[i + 1].n == 2 * t - 1)
                    {
                        Split_Child(i + 1, Child[i + 1]);
                        if (keys[i + 1] < target) { i++; }
                    }
                    Child[i + 1].InsertAfterSplit(root, target);
                }
            }                                                                                                       

            public void Remove(BTreeNode x, int target)
            {
                int pos = x.Find(target); // go try to find value in current node
                if (pos != -1) // if the value is found
                {
                    if (x.leaf) // if this is a leaf node
                    {
                        int i = 0;
                        for (i = 0; i < x.n && x.keys[i] != target; i++) { } // just count up
                        ;
                        for (; i < x.n; i++)
                        {
                            if (i != 2 * t - 2) { x.keys[i] = x.keys[i + 1]; } // copy one value to remove targeted value
                        }
                        x.n--;
                        return;
                    }
                    if (!x.leaf) // is internal node
                    {
                        BTreeNode pred = x.Child[pos]; // create empty node to copy
                        int predKey = 0;
                        if (pred.n >= t)
                        {
                            if (pred.leaf)
                            {
                                predKey = pred.keys[pred.n - 1];
                            }
                            else
                            {
                                pred = pred.Child[pred.n];
                            }
                            Remove(pred, predKey);
                            x.keys[pos] = predKey;
                            return;
                        }
                        BTreeNode nextNode = x.Child[pos + 1];
                        if (nextNode.n >= t)
                        {
                            int nextKey = nextNode.keys[0];
                            if (!nextNode.leaf)
                            {
                                nextNode = nextNode.Child[0];
                                for (; ; )
                                {
                                    if (nextNode.leaf)
                                    {
                                        nextKey = nextNode.keys[nextNode.n - 1];
                                        break;
                                    }
                                    else
                                    {
                                        nextNode = nextNode.Child[nextNode.n];
                                    }
                                }
                            }
                            Remove(nextNode, nextKey);
                            x.keys[pos] = nextKey;
                            return;
                        }

                        int temp = pred.n + 1;
                        pred.keys[pred.n++] = x.keys[pos];
                        for (int i = 0, j = pred.n; i < nextNode.n; i++)
                        {
                            pred.keys[j++] = nextNode.keys[i];
                            pred.n++;
                        }
                        for (int i = 0; i < nextNode.n + 1; i++)
                        {
                            pred.Child[temp++] = nextNode.Child[i];
                        }

                        x.Child[pos] = pred;
                        for (int i = pos; i < x.n; i++)
                        {
                            if (i != 2 * t - 2)
                            {
                                x.keys[i] = x.keys[i + 1];
                            }
                        }
                        for (int i = pos + 1; i < x.n + 1; i++)
                        {
                            if (i != 2 * t - 1)
                            {
                                x.Child[i] = x.Child[i + 1];
                            }
                        }
                        x.n--;
                        if (x.n == 0)
                        {
                            x = x.Child[0];
                        }
                        Remove(pred, target);
                        return;
                    }
                }
                else
                {
                    for (pos = 0; pos < x.n; pos++) // checks to find if target is greater than cur value
                    {
                        if (x.keys[pos] > target) { break; } // is the target value identified
                    }
                    BTreeNode tmp = x.Child[pos]; // create a temp node to remove wrong entries and move up one index
                    try // error catch if no value found
                    {
                        if (tmp.n >= t) // is this at max degree?
                        {
                            Remove(tmp, target); // remove this value
                            return;
                        }
                        else
                        {
                            BTreeNode nb;
                            int divider = -1;

                            if (pos != x.n && x.Child[pos + 1].n >= t)
                            {
                                divider = x.keys[pos];
                                nb = x.Child[pos + 1];
                                x.keys[pos] = nb.keys[0];
                                tmp.keys[tmp.n++] = divider;
                                tmp.Child[tmp.n] = nb.Child[0];
                                for (int i = 1; i < nb.n; i++)
                                {
                                    nb.keys[i - 1] = nb.keys[i];
                                }
                                for (int i = 1; i <= nb.n; i++)
                                {
                                    nb.Child[i - 1] = nb.Child[i];
                                }
                                nb.n--;
                                Remove(tmp, target);
                                return;
                            }
                            else if (pos != 0 && x.Child[pos - 1].n >= t)
                            {

                                divider = x.keys[pos - 1];
                                nb = x.Child[pos - 1];
                                x.keys[pos - 1] = nb.keys[nb.n - 1];
                                BTreeNode child = nb.Child[nb.n];
                                nb.n--;

                                for (int i = tmp.n; i > 0; i--)
                                {
                                    tmp.keys[i] = tmp.keys[i - 1];
                                }
                                tmp.keys[0] = divider;
                                for (int i = tmp.n + 1; i > 0; i--)
                                {
                                    tmp.Child[i] = tmp.Child[i - 1];
                                }
                                tmp.Child[0] = child;
                                tmp.n++;
                                Remove(tmp, target);
                                return;
                            }
                            else
                            {
                                BTreeNode lt;
                                BTreeNode rt;
                                if (pos != x.n)
                                {
                                    divider = x.keys[pos];
                                    lt = x.Child[pos];
                                    rt = x.Child[pos + 1];
                                }
                                else
                                {
                                    divider = x.keys[pos - 1]; // splits nodes into two
                                    rt = x.Child[pos];
                                    lt = x.Child[pos - 1];
                                    pos--;
                                }
                                for (int i = pos; i < x.n - 1; i++) // copies keys
                                {
                                    x.keys[i] = x.keys[i + 1];
                                }
                                for (int i = pos + 1; i < x.n; i++) // copies chid nodes and contained keys
                                {
                                    x.Child[i] = x.Child[i + 1];
                                }
                                x.n--; // moves up a node
                                lt.keys[lt.n++] = divider; // selected number is transferred into left node key

                                for (int i = 0, j = lt.n; i < rt.n + 1; i++, j++) // increments and copies keys and children
                                {
                                    if (i < rt.n)
                                    {
                                        lt.keys[j] = rt.keys[i];
                                    }
                                    lt.Child[j] = rt.Child[i];
                                }
                                lt.n += rt.n; // add n together
                                if (x.n == 0) // if at root node
                                {
                                    x = x.Child[0]; // copy the child into the parent
                                }
                                Remove(lt, target); // recursively go through to remove target
                                return;
                            }
                        }
                    }
                    catch
                    {
                        WriteLine("The entry does not exist.");
                    }
                }
            }

            public static void Main()
            {
                Btree btree = new Btree(3);

                WriteLine("Hello, and welcome to my program. This program is designed for you to enter receipt information, ");
                Write("sort it, delete it, and view.\nPress return to continue. (Type Exit to quit)\n");
                string userInput = ReadLine();

                while (!string.Equals(userInput, "Exit", StringComparison.OrdinalIgnoreCase))
                {
                    WriteLine("\nPlease select from the following options:\n1: Add entry\n2. Search entry\n3. Delete entry" +
                        "\n4. View entries\nType 'Exit' to exit.\n");
                    userInput = ReadLine();
                    switch (userInput)
                    {
                        case "1":
                            try
                            {

                                WriteLine("\nPlease enter a date (format yyyyMMdd): ");
                                int date = int.Parse(ReadLine());
                                WriteLine("\nPlease enter a payee: ");
                                object payee = ReadLine();
                                WriteLine("\nPlease enter a payee: ");
                                object debit = ReadLine();

                                btree.Insert(date, payee, debit);

                            }
                            catch
                            {
                                WriteLine("Your format is invalid. Press a key to continue.");
                                ReadKey();
                            }
                            break;
                        case "2":
                            WriteLine("Enter a date: ");
                            try
                            {
                                int convert = int.Parse(ReadLine());
                                btree.Search(convert);
                            }
                            catch
                            {
                                WriteLine("Your format is invalid or it does not exist. Press a key to continue.");
                                ReadKey();
                            }
                            break;
                        case "3":
                            WriteLine("\nIn order to delete, please identify the date (format YYYYMMDD): ");
                            int del = int.Parse(ReadLine());
                            btree.Remove(del);
                            break;
                        case "4":
                            WriteLine();
                            WriteLine(
                                format: "{0,-8} {1,5:N0} {2,13}",
                                arg0: "Date",
                                arg1: "Payee",
                                arg2: "Amount"
                            );


                            btree.Traverse();
                            break;
                        default:
                            WriteLine("Please enter a valid selection.");
                            break;
                    }
                }


            }
        }
    }
}