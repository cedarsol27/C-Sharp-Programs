using System;
namespace Graph
{
    public class Edge<T>
    {
        public Node<T> From { get; set; } // From one node
        public Node<T> To { get; set; } // To the next
        public int Weight { get; set; } // weight of the edge

        public override string ToString()
        {
            return $"Edge: {From.Data} -> {To.Data}, weight: {Weight}";
        }
    }
}
