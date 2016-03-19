using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonLambda.Competitive.TopCoder.Practice
{
    public class DoubleWeights
    {
        public int minimalCost(string[] weight1, string[] weight2)
        {
            var vtxToDistane = DijkstraShortestPathCost(Generate(weight1.Length), 0,
                (u, v) => GetEdgeCost(u, v, weight1, weight2));


            return vtxToDistane[1] == int.MaxValue ? -1 : vtxToDistane[1];
        }

        public IEnumerable<int> Generate(int len)
        {
            var r = new int[len];

            for(int i = 0; i< len; i++)
            {
                r[i] = i;
            }

            return r;
        }

        public int? GetEdgeCost(int u, int v, string[] weight1, string[] weight2)
        {
            if (weight1[u][v] == '.')
                return null;


            return int.Parse(weight1[u][v].ToString()) * int.Parse(weight2[u][v].ToString());
        }

        public IDictionary<TVertex, int> DijkstraShortestPathCost<TVertex>(IEnumerable<TVertex> vertices, TVertex source, Func<TVertex, TVertex, int?> GetEdgeCost)
        {
            IEnumerable<Tuple<TVertex, int>> vertexInfo = new List<Tuple<TVertex, int>>(vertices.Select(v => new Tuple<TVertex, int>(v, int.MaxValue)));
            var distances = vertices.ToDictionary(v => v, v => int.MaxValue);
            var prev = new Dictionary<TVertex, TVertex>();

            distances[source] = 0;

            while(vertexInfo.Any())
            {
                vertexInfo = vertexInfo.OrderBy(info => info.Item2);
                var u = vertexInfo.First().Item1;
                vertexInfo = vertexInfo.Skip(1);

                var neighbours = vertices.Where(v => GetEdgeCost(v, u).HasValue);
                foreach(var v in neighbours)
                {
                    var alt = distances[u] == int.MaxValue ? int.MaxValue : distances[u] + GetEdgeCost(u, v).Value;

                    if (alt < distances[v])
                    {
                        distances[v] = alt;
                        prev[v] = u;
                    }
                }
            }

            return distances;
        }
    }
}
