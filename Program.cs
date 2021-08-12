using System;
using System.Collections.Generic;

namespace GraphResolver
{
    class Program
    {
        // fill edges data for testing...
        private static List<Tuple<int, int>> _edges = new List<Tuple<int, int>>() {
            new Tuple<int, int>(1, 2),
            new Tuple<int, int>(1, 3),
            new Tuple<int, int>(2, 4),
            new Tuple<int, int>(3, 4),
            new Tuple<int, int>(4, 5),
            new Tuple<int, int>(4, 6),
            //------------------------
            new Tuple<int, int>(5, 15),

            new Tuple<int, int>(5, 7),
            new Tuple<int, int>(6, 7),
            new Tuple<int, int>(7, 8),
            new Tuple<int, int>(7, 9),
            new Tuple<int, int>(8, 10),
            new Tuple<int, int>(9, 10),
            new Tuple<int, int>(10, 11),
            new Tuple<int, int>(10, 12),

            new Tuple<int, int>(12, 120),
            new Tuple<int, int>(120, 88),


            new Tuple<int, int>(88, 33),
            new Tuple<int, int>(88, 55),
        };

        static void Main(string[] args)
        {
            Console.WriteLine("GraphResolver started.");

            var result = GraphResolver.ConnectingPaths(_edges, 1, 4);

            foreach (var route in result)
            {
                Console.Write(string.Join(",", route.ToArray()));
                Console.WriteLine();
            }

            Console.WriteLine("GraphResolver finished.");
            Console.ReadLine();
        }
    }
}
