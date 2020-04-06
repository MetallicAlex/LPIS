using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first vertex: ");
            int firstVertex = int.Parse(Console.ReadLine());
            Console.Write("Enter last vertex: ");
            int lastVertex = int.Parse(Console.ReadLine());
            Graph graph = new Graph();
            graph.LoadGraph(@"..\..\..\GraphData.txt");
            graph.ShowAdjacencyList();
            graph.DepthFirstSearch(firstVertex, lastVertex);
            graph.ShowPath();
        }
    }
}
