using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Graph
{
    class Program
    {
        static void Main()
        {

            /*-------------------Undirected and unweighted edges------------------------------*/

            //Graph<int> graph = new Graph<int>(false, false); // initiate a unidirectional graph

            //Node<int> n1 = graph.AddNode(1); // add numbered nodes
            //Node<int> n2 = graph.AddNode(2);
            //Node<int> n3 = graph.AddNode(3);
            //Node<int> n4 = graph.AddNode(4);
            //Node<int> n5 = graph.AddNode(5);
            //Node<int> n6 = graph.AddNode(6);
            //Node<int> n7 = graph.AddNode(7);
            //Node<int> n8 = graph.AddNode(8);

            //graph.AddEdge(n1, n2); // add edges between nodes
            //graph.AddEdge(n1, n3);
            //graph.AddEdge(n2, n4);
            //graph.AddEdge(n3, n4);
            //graph.AddEdge(n4, n5);
            //graph.AddEdge(n5, n6);
            //graph.AddEdge(n5, n7);
            //graph.AddEdge(n5, n8);
            //graph.AddEdge(n6, n7);
            //graph.AddEdge(n7, n8);

            //List<Node<int>> dfsNodes = graph.DFS(); // returns a list of Node instances
            //dfsNodes.ForEach(n => WriteLine(n));

            /*-------------------Undirected and weighted edges------------------------------*/

            //Graph<int> graph = new Graph<int>(false, true);

            //Node<int> n1 = graph.AddNode(1); // add numbered nodes
            //Node<int> n2 = graph.AddNode(2);
            //Node<int> n3 = graph.AddNode(3);
            //Node<int> n4 = graph.AddNode(4);
            //Node<int> n5 = graph.AddNode(5);
            //Node<int> n6 = graph.AddNode(6);
            //Node<int> n7 = graph.AddNode(7);
            //Node<int> n8 = graph.AddNode(8);

            // graph.AddEdge(n1, n2, 3);
            // graph.AddEdge(n1, n3, 5);
            // graph.AddEdge(n2, n4, 4);
            // graph.AddEdge(n3, n4, 12);
            // graph.AddEdge(n4, n5, 9);
            // graph.AddEdge(n4, n8, 8);
            // graph.AddEdge(n5, n6, 4);
            // graph.AddEdge(n5, n7, 5);
            // graph.AddEdge(n5, n8, 1);
            // graph.AddEdge(n6, n7, 6);
            // graph.AddEdge(n7, n8, 20);
            // graph.AddEdge(n2, n6, 20);
            // graph.AddEdge(n2, n5, 20);

            /*-------------------Directed and weighted edges------------------------------*/
            WriteLine("New Graph 1");
            Graph<int> graph = new Graph<int>(true, true);

            Node<int> n1 = graph.AddNode(1); // you can add these to a file
            Node<int> n2 = graph.AddNode(2);
            Node<int> n3 = graph.AddNode(3);
            Node<int> n4 = graph.AddNode(4);
            Node<int> n5 = graph.AddNode(5);
            Node<int> n6 = graph.AddNode(6);
            Node<int> n7 = graph.AddNode(7);
            Node<int> n8 = graph.AddNode(8);

            graph.AddEdge(n1, n2, 9); // you can add these to a file
            graph.AddEdge(n1, n3, 5);
            graph.AddEdge(n2, n1, 3);
            graph.AddEdge(n2, n4, 18);
            graph.AddEdge(n3, n4, 12);
            graph.AddEdge(n4, n2, 2);
            graph.AddEdge(n4, n8, 8);
            graph.AddEdge(n5, n4, 9);
            graph.AddEdge(n5, n6, 2);
            graph.AddEdge(n5, n7, 5);
            graph.AddEdge(n5, n8, 3);
            graph.AddEdge(n6, n7, 1);
            graph.AddEdge(n7, n5, 4);
            graph.AddEdge(n7, n8, 6);
            graph.AddEdge(n8, n5, 3);

            List<Node<int>> dfsNodes = graph.DFS(); // returns a list of Node instances
            dfsNodes.ForEach(n => WriteLine(n));



            /*-------------------Kruskal's Algorithm------------------------------*/

            //List<Edge<int>> mstKruskal = graph.MSTKruskal();
            //mstKruskal.ForEach(e => WriteLine(e));



            /*-------------------Prim's Algorithm------------------------------*/

            //List<Edge<int>> mstPrim = graph.MSTPrim();
            //mstPrim.ForEach(e => WriteLine(e));

            /*-------------------Depth-First Search------------------------------*/

            //List<Node<int>> dfsNodes = graph.DFS(); // returns a list of Node instances
            //dfsNodes.ForEach(n => WriteLine(n));

            /*-------------------Breadth-first Search------------------------------*/
            //List<Node<int>> bfsNodes = graph.BFS(); // returns a list of Node instances
            //bfsNodes.ForEach(n => WriteLine(n));





            /*-------------------telecomm cable------------------------------*/
            //WriteLine("Start example here: \n");

            //Graph<string> graph = new Graph<string>(false, true);

            //Node<string> nodeb1 = graph.AddNode("b1");
            //Node<string> nodeb2 = graph.AddNode("b2");
            //Node<string> nodeb3 = graph.AddNode("b3");
            //Node<string> nodeb4 = graph.AddNode("b4");
            //Node<string> nodeb5 = graph.AddNode("b5");
            //Node<string> nodeb6 = graph.AddNode("b6");
            //Node<string> noder1 = graph.AddNode("r1");
            //Node<string> noder2 = graph.AddNode("r2");
            //Node<string> noder3 = graph.AddNode("r3");
            //Node<string> noder4 = graph.AddNode("r4");
            //Node<string> noder5 = graph.AddNode("r5");
            //Node<string> noder6 = graph.AddNode("r6");

            //graph.AddEdge(nodeb1, nodeb2, 2);
            //graph.AddEdge(nodeb1, nodeb3, 20);
            //graph.AddEdge(nodeb1, nodeb4, 30);
            //graph.AddEdge(nodeb2, nodeb4, 20);
            //graph.AddEdge(nodeb2, nodeb3, 30);
            //graph.AddEdge(nodeb3, nodeb4, 2);
            //graph.AddEdge(nodeb2, noder2, 25);
            //graph.AddEdge(nodeb4, noder4, 25);
            //graph.AddEdge(noder1, noder2, 1);
            //graph.AddEdge(noder2, noder3, 1);
            //graph.AddEdge(noder3, noder4, 1);
            //graph.AddEdge(noder1, noder5, 75);
            //graph.AddEdge(noder3, noder6, 100);
            //graph.AddEdge(noder5, noder6, 3);
            //graph.AddEdge(noder6, nodeb6, 10);
            //graph.AddEdge(noder6, nodeb5, 3);
            //graph.AddEdge(nodeb5, nodeb6, 6);


            //List<Edge<string>> mstPrim = graph.MSTPrim();
            //mstPrim.ForEach(e => WriteLine(e));
            //WriteLine("Total Cost: " + mstPrim.Sum(e => e.Weight));
        }
    }
}

