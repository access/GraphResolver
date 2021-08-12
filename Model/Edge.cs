using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphResolver.Model
{
    public class Edge
    {
        public Vertex From { get; set; }
        public Vertex To { get; set; }
        public override string ToString() => $"({From}; {To})";

        public Edge(Vertex from, Vertex to)
        {
            From = from;
            To = to;
        }
    }
}
