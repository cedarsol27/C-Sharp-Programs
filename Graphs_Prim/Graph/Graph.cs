using System;
using System.Collections.Generic;

namespace Graph
{
    public class Graph<T> // applies to either directed or undirected edges and weighted/unweighted edges
    {
        private bool _isDirected = false; // indicates whether directed
        private bool _isWeighted = false; // indicates whether weighted
        public List<Node<T>> Nodes { get; set; } = new List<Node<T>>(); // stores a list of nodes existing in the graph


        public Edge<T> this[int from, int to]
        {
            get // get instances of node class with connected nodes From and To via index
            {
                Node<T> nodeFrom = Nodes[from];
                Node<T> nodeTo = Nodes[to];
                int i = nodeFrom.Neighbors.IndexOf(nodeTo); // find neighboring node via IndexOF()
                if (i >= 0)
                {
                    Edge<T> edge = new Edge<T>() // if connection exists, create new instance of Edge class and set values
                    {
                        From = nodeFrom,
                        To = nodeTo,
                        Weight = i < nodeFrom.Weights.Count ? nodeFrom.Weights[i] : 0 // if weight exists, set the weight
                    };
                    return edge;
                }
                return null; // if connection doesn't exist, return does not exist
            }
        }


        public Graph(bool isDirected, bool isWeighted) // a constructor class
        {
            _isDirected = isDirected;
            _isWeighted = isWeighted;
        }

        public Node<T> AddNode(T value)
        {
            Node<T> node = new Node<T>() { Data = value }; // create new instance of node class, set value of data
            Nodes.Add(node); // add nodes to Nodes collection
            UpdateIndices(); // updates all indices of all nodes stored in collection
            return node; // return newly added node
        }


        public void AddEdge(Node<T> from, Node<T> to, int weight = 0) // takes parameters from, to, and the weight of connection
        {
            from.Neighbors.Add(to); // add the node instance representing the second node to the list of neighbors to the first one
            if (_isWeighted) // takes into account if there is a weight
            {
                from.Weights.Add(weight);
            }
            if (!_isDirected) // takes into account if it is undirectional
            {
                to.Neighbors.Add(from); // add direction in opposite direction
                if (_isWeighted) // if it is weighted, add to the weight as well
                {
                    to.Weights.Add(weight);
                }
            }
        }

        /*-------------------Removing Nodes------------------------------*/

        public void RemoveNode(Node<T> nodeToRemove)
        {
            Nodes.Remove(nodeToRemove); // remove from collection of nodes
            UpdateIndices(); // update indices of remaining nodes
            foreach (Node<T> node in Nodes) // iterate through remaining nodes to remove edges from removed node
            {
                RemoveEdge(node, nodeToRemove);
            }
        }

        public void RemoveEdge(Node<T> from, Node<T> to) // takes parameters from and to and identify the edge
        {
            int index = from.Neighbors.FindIndex(n => n == to); // first, find the second node from the first node
            if (index == 0)
            {
                from.Neighbors.RemoveAt(index); // if found, remove it
                if (_isWeighted) // if weighted, also remove
                {
                    from.Weights.RemoveAt(index);
                }
            }
        }

        public List<Edge<T>> GetEdges()
        {
            List<Edge<T>> edges = new List<Edge<T>>(); // create a new list to iterate through
            foreach (Node<T> from in Nodes)
            {
                for (int i = 0; i < from.Neighbors.Count; i++)
                {
                    Edge<T> edge = new Edge<T>() // configure properties 
                    {
                        From = from, // the from node
                        To = from.Neighbors[i], // currently analyzed neighbor
                        Weight = i < from.Weights.Count ? from.Weights[i] : 0 // and the weight
                    };
                    edges.Add(edge); // now added to collection of edges
                }
            }
            return edges; // return result
        }

        private void UpdateIndices() // this goes through all nodes and updates the values of the Index property
        {
            int i = 0;
            Nodes.ForEach(n => n.index = i++); // uses a ForEach method, not a foreach loop
        }

        /*-------------------Depth-First Search------------------------------*/

        public List<Node<T>> DFS()
        {
            bool[] isVisited = new bool[Nodes.Count]; // gives the value if a node has been visited, has same number of elements as nodes 
            List<Node<T>> result = new List<Node<T>>();
            DFS(isVisited, Nodes[0], result); // value is stored, whether true or false, and list is traverses, passing three parameters
            return result;
        }

        private void DFS(bool[] isVisited, Node<T> node, List<Node<T>> result)
        {
            result.Add(node); // add current node to collection of traversed nodes
            isVisited[node.index] = true; // element in the array is updated
            
            foreach (Node<T> neighbor in node.Neighbors) // iterate through all neighbor of current node
            {
                if (!isVisited[neighbor.index]) // if not visited, DFS is called recursively
                {
                    DFS(isVisited, neighbor, result);
                }
            }
        }


        /*-------------------Breadth-first Search------------------------------*/

        public List<Node<T>> BFS() // starts the traversal
        {
            return BFS(Nodes[0]);
        }

        private List<Node<T>> BFS(Node<T> node)
        {
            bool[] isVisited = new bool[Nodes.Count]; // creates an array to store boolean values if node has been visited
            isVisited[node.index] = true; // applies when node is visited
            List<Node<T>> result = new List<Node<T>>(); // stores a list of visited nodes
            Queue<Node<T>> queue = new Queue<Node<T>>(); // nodes still waiting to be visited
            queue.Enqueue(node); // add the node
            while (queue.Count > 0) // 
            {
                Node<T> next = queue.Dequeue(); // get next node
                result.Add(next); // add it to collection of visited nodes
                foreach (Node<T> neighbor in next.Neighbors) // and iterate through neighbors of current node
                {
                    if (!isVisited[neighbor.index])
                    {
                        isVisited[neighbor.index] = true; // sets a value to true for visited
                        queue.Enqueue(neighbor);
                    }
                }
            }
            return result;
        }


        /*-------------------Kruskal's Algorithm------------------------------*/

        public List<Edge<T>> MSTKruskal()
        {
            List<Edge<T>> edges = GetEdges(); // get a list of edges
            edges.Sort((a, b) => a.Weight.CompareTo(b.Weight)); // sort ascending by weight
            Queue<Edge<T>> queue = new Queue<Edge<T>>(edges); // edges instances are queued in new queue

            Subset<T>[] subsets = new Subset<T>[Nodes.Count]; // Each node is added to it's own subset. subsets check if addition of edge causes creation of cycle
            for (int i = 0; i < Nodes.Count; i++)
            {
                subsets[i] = new Subset<T>() { Parent = Nodes[i] };
            }

            List<Edge<T>> result = new List<Edge<T>>(); // store list of edges
            while (result.Count < Nodes.Count - 1) // iterates until the correct number of edges found
            {
                Edge<T> edge = queue.Dequeue(); // get edge with min weight
                Node<T> from = GetRoot(subsets, edge.From); 
                Node<T> to = GetRoot(subsets, edge.To);
                if (from != to) // check if no other cycles were introduced
                {
                    result.Add(edge);
                    Union(subsets, from, to); // union two subsets
                }
            }
            return result;
        }

        private Node<T> GetRoot(Subset<T>[] subsets, Node<T> node)
        {
            if (subsets[node.index].Parent != node)
            {
                subsets[node.index].Parent = GetRoot(subsets, subsets[node.index].Parent);
            }
            return subsets[node.index].Parent;
        }

        private void Union(Subset<T>[] subsets, Node<T> a, Node<T> b)
        {
            if (subsets[a.index].Rank > subsets[b.index].Rank)
            {
                subsets[b.index].Parent = a;
            }
            else if (subsets[a.index].Rank < subsets[b.index].Rank)
            {
                subsets[a.index].Parent = b;
            }
            else
            {
                subsets[b.index].Parent = a;
                subsets[a.index].Rank++;
            }
        }

        public class Subset<T>
        {
            public Node<T> Parent { get; set; }
            public int Rank { get; set; }

            public override string ToString()
            {
                return $"Subset with rank {Rank}, parent {Parent.Data}, index: {Parent.index}";
            }
        }
        /*-------------------Prims Algorithm------------------------------*/

        public List<Edge<T>> MSTPrim()
        {
            int[] previous = new int[Nodes.Count]; // stores indices of previous node
            previous[0] = -1; // all other values are 0

            int[] minWeight = new int[Nodes.Count]; // stores minimum weight of the edge of the given node
            Fill(minWeight, int.MaxValue); // store max value of int type
            minWeight[0] = 0; // first value is set to 0

            bool[] isInMST = new bool[Nodes.Count]; // indicates whether a given node is already in the MST
            Fill(isInMST, false); // all values are set to false

            for (int i = 0; i < Nodes.Count - 1; i++)
            {
                int minWeightIndex = GetMinimumWeightIndex(minWeight, isInMST); // identifies the minimum weight vale of nodes not in MST
                isInMST[minWeightIndex] = true;

                for (int j = 0; j < Nodes.Count; j++)
                {
                    Edge<T> edge = this[minWeightIndex, j]; // get edge that connects node with index
                    int weight = edge != null ? edge.Weight : -1;
                    if (edge != null && !isInMST[j] && weight < minWeight[j]) // is it in the MST??
                    {
                        previous[j] = minWeightIndex; // values are updated
                        minWeight[j] = weight;
                        Console.WriteLine(" --> " + edge.ToString());
                    }
                }
            }
            List<Edge<T>> result = new List<Edge<T>>(); // create list and add to result list
            for (int i = 1; i < Nodes.Count; i++)
            {
                Edge<T> edge = this[previous[i], i];
                result.Add(edge);
            }
            return result;
        }

        private int GetMinimumWeightIndex(int[] weights, bool[] isInMST)
        {
            int minValue = int.MaxValue; // finds index, not located in the MST and reach at min cost
            int minIndex = 0;

            for (int i = 0; i < Nodes.Count; i++) // check to see if in MST
            {
                if (!isInMST[i] && weights[i] < minValue) // values are update if so
                {
                    minValue = weights[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }

        private void Fill<Q>(Q[] array, Q value) // passes values of all elements in the array to the value passes as the second parameter
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }
        }
    }
}