using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonLambda.Competitive.TopCoder.Practice
{
    public class MultiplicationTable2Easy
    {
        public string isGoodSet(int[] table, int[] t)
        {
            return (!IsGood(table, t) ? "Not " : string.Empty) + "Good";
        }

        public bool IsGood(int[] table, int[] t)
        {
            int n = (int)Math.Sqrt((double)table.Length);
            IEnumerable<Tuple<int, int>> cartesianT2 = GetCartesianProduct(t, t);

            var setOfT = new HashSet<int>(t);

            return cartesianT2.All(pairOfT => setOfT.Contains(ApplyOperator(table, n, pairOfT.Item1, pairOfT.Item2)));
        }

        internal int ApplyOperator(int[] table, int n, int i, int j)
        {
            return table[i * n + j];
        }

        internal IEnumerable<Tuple<T1,T2>> GetCartesianProduct<T1, T2>(IEnumerable<T1> c1, IEnumerable<T2> c2)
        {
            return c1.Select(i => c2.Select(j => new Tuple<T1, T2>(i, j))).Aggregate((acc, current) => acc.Concat(current));
        }
    }
}
