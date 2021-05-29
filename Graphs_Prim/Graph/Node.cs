using System.Collections.Generic;

namespace Graph
{
    public class Node<T>
    {
        public int index { get; set; } // stores index of node, helps get an instance of the node class
        public T Data { get; set; } // Just stores some data. Notice <T> type
        public List<Node<T>> Neighbors { get; set; } = new List<Node<T>>(); // Represents the adjacency list of a particular node
        public List<int> Weights { get; set; } = new List<int>(); // stores weights assigned to adjacent edges. An unweighted graph list is empty

        public override string ToString()
        {
            return $"Node with index {index}: {Data}, neighbors: {Neighbors.Count}"; // returns text representationof the object
        }
    }
}
