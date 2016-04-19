using System.Collections.Generic;

namespace EpsilonLambda.Competitive.TopCoder.Practice
{
    public class ExactTreeEasy
    {
        public int[] getTree(int n, int m)
        {
            var result = new List<int>();
            int nonLeaves = n - m;

            // Level 1
            for(int i = 0; i < nonLeaves - 1; i++)
            {
                result.Add(i);
                result.Add(i + 1);

                result.Add(i);
                result.Add(nonLeaves + i);
            }

            // Last Group : Connect all remaining to last non-leaf

            for (int i = nonLeaves * 2 - 1; i < n; i++)
            {
                result.Add(nonLeaves - 1);
                result.Add(i);
            }

            return result.ToArray();
        }
    }
}
