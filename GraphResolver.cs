using GraphResolver.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphResolver
{
    class GraphResolver
    {
        public static List<List<int>> ConnectingPaths(List<Tuple<int, int>> graph, int node1, int node2)
        {
            var newGraph = new Graph();

            // init graph vertexes and edges
            foreach (var edge in graph)
            {
                var vertexFrom = newGraph.AddVertex(edge.Item1);
                var vertexTo = newGraph.AddVertex(edge.Item2);
                newGraph.AddEdge(vertexFrom, vertexTo);
            }

            return newGraph.GetRoutes(node1, node2);
        }

    }
}
