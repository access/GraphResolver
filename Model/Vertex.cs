using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphResolver.Model
{
    public class Vertex
    {
        public int Number { get; set; }
        public Vertex(int number) => Number = number;
        public bool Visited { get; set; }
        public override string ToString() => Number.ToString();
    }
}
