using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphResolver.Model
{
    public class Graph
    {
        private HashSet<int> _UniqueVertexes = new HashSet<int>();
        private List<Vertex> _Vertexes = new List<Vertex>();
        private List<Edge> _Edges = new List<Edge>();
        private List<List<int>> _AvailableRoutes = new List<List<int>>();

        public int VertexCount => _Vertexes.Count;
        public int EdgesCount => _Edges.Count;

        public Vertex AddVertex(int vertex)
        {
            var newVertex = new Vertex(vertex);
            if (_UniqueVertexes.Add(vertex))
                _Vertexes.Add(newVertex);
            else
                foreach (var v in _Vertexes)
                    if (v.Number == vertex)
                        return v;
            return newVertex;
        }

        public void AddEdge(Vertex from, Vertex to)
        {
            var edge = new Edge(from, to);
            _Edges.Add(edge);
        }

        public List<Vertex> GetToVertexesList(Vertex vertex)
        {
            var result = new List<Vertex>();

            foreach (var edge in _Edges)
                if (edge.From == vertex)
                    result.Add(edge.To);
            return result;
        }

        public Vertex GetVertexByValue(int val)
        {
            foreach (var v in _Vertexes)
                if (v.Number == val)
                    return v;
            return null;
        }

        public List<List<int>> GetRoutes(int start, int finish)
        {
            // get start and finish Vertexes
            var startVertex = GetVertexByValue(start);
            var finishVertex = GetVertexByValue(finish);

            GenerateAvailableRoutes(startVertex, finishVertex);

            var neededList = new List<List<int>>();
            foreach (var route in _AvailableRoutes)
            {
                if (route.Contains(start) && route.Contains(finish))
                {
                    int startIdx = route.IndexOf(start);
                    int finishIdx = route.IndexOf(finish);
                    var routeVertexes = route.GetRange(startIdx, finishIdx - startIdx + 1);
                    neededList.Add(routeVertexes);
                }
            }

            // remove duplicates
            var distinct = neededList.Select(x => new HashSet<int>(x)).Distinct(HashSet<int>.CreateSetComparer());
            var outList = new List<List<int>>();
            foreach (var list in distinct)
                outList.Add(list.ToList());
            return outList;
        }

        private void GenerateAvailableRoutes(Vertex start, Vertex finish)
        {
            bool endOfBranch = false;
            var tmpRoute = new LinkedList<Vertex>();
            var currentVertex = start;

            tmpRoute.AddFirst(start);
            while (tmpRoute.Count > 0)
            {
                if (endOfBranch)
                {
                    tmpRoute.RemoveLast();
                    if (tmpRoute.Last != null)
                        currentVertex = tmpRoute.Last.Value;
                }

                var neighborList = GetToVertexesList(currentVertex);
                if (neighborList.Count > 0)
                {
                    bool hasNotVisited = false;
                    foreach (var vertex in neighborList)
                    {
                        if (!vertex.Visited)
                        {
                            hasNotVisited = true;
                            tmpRoute.AddLast(vertex);
                            vertex.Visited = true;
                            currentVertex = vertex;
                            endOfBranch = false;
                            break;
                        }
                    }
                    if (!hasNotVisited)
                    {
                        if (!endOfBranch)
                            CleanVisists(currentVertex);
                        else
                        {
                            if (!endOfBranch)
                                tmpRoute.RemoveLast();
                            if (tmpRoute.Last != null)
                                currentVertex = tmpRoute.Last.Value;
                        }
                    }
                }
                else
                {
                    endOfBranch = true;
                    _AvailableRoutes.Add(tmpRoute.Select((item) => (item.Number)).ToList());
                }
            }
        }

        private void CleanVisists(Vertex currentVertex)
        {
            foreach (var vertex in GetToVertexesList(currentVertex))
            {
                vertex.Visited = false;
                CleanVisists(vertex);
            }
        }
    }
}
