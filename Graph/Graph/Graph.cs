using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Graph
{
    class Graph
    {
        private List<List<int>> adjacencyList;
        private List<bool> visitVertex;
        private Stack<int> pathGraph;
        public void LoadGraph(string path)
        {
            adjacencyList = new List<List<int>>();
            visitVertex = new List<bool>();
            int indexList = 0;
            string line;
            StreamReader file = new StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                adjacencyList.Add(new List<int>());
                visitVertex.Add(false);
                string[] listNode = line.Split(new char[] { ',', ' ' });
                foreach (var node in listNode)
                {
                    adjacencyList[indexList].Add(int.Parse(node));
                }
                indexList++;
            }
        }
        public void ShowAdjacencyList()
        {
            Console.WriteLine("Adjacency List");
            for (int i = 0; i < adjacencyList.Count; i++)
            {
                Console.Write(i.ToString() + ": [");
                Console.Write(string.Join(",", adjacencyList[i]));
                Console.WriteLine("]");
            }
        }
        public void DepthFirstSearch(int firstVertex, int lastVertex)
        {
            pathGraph = new Stack<int>();
            int vertex = firstVertex;
            pathGraph.Push(vertex);
            visitVertex[vertex] = true;
            bool pathNotFound;
            while (vertex != lastVertex)
            {
                pathNotFound = true;
                foreach (var adjacentVertex in adjacencyList[vertex])
                {
                    if(!visitVertex[adjacentVertex])
                    {
                        pathGraph.Push(adjacentVertex);
                        visitVertex[adjacentVertex] = true;
                        vertex = adjacentVertex;
                        pathNotFound = false;
                        break;
                    }
                }
                if(pathNotFound)
                {
                    vertex = pathGraph.Pop();
                    foreach(var adjacentVertex in adjacencyList[vertex])
                    {
                        if(!visitVertex[adjacentVertex])
                        {
                            pathGraph.Push(vertex);
                            break;
                        }
                    }
                }
            }
        }
        public void ShowPath()
        {
            Console.Write("Path of Graph: ");
            if (pathGraph.Count == 0)
                Console.WriteLine("Path not found");
            else Console.WriteLine(string.Join(" -> ", pathGraph.Reverse()));
            Console.ReadKey();
        }
    }
}
