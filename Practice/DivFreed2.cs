using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonLambda.Competitive.TopCoder.Practice
{
    public class DivFreed2
    {
        public int count(int n, int k)
        {
            ubound = k;
            lbound = 1;

            var firstElements = getRange(lbound, ubound);

            var solutions = getSolutions(n, k, firstElements);

            // int overflow?
            return solutions.Select(s => s.Count).Sum() % 1000000007;
        }

        public class SolutionInfo
        {
            public int First { get; private set; }
            public int Count { get; private set; }

            public SolutionInfo(int first, int count)
            {
                First = first;
                Count = count;
            }
        }

        int ubound, lbound;
        public IEnumerable<SolutionInfo> getSolutions(int n, int k, IEnumerable<int> firstItemCandidates)
        {
            if (n == 1) return firstItemCandidates.Select(x => new SolutionInfo(x, 1)); // TODO: uzhas!

            List<SolutionInfo> solutions = new List<SolutionInfo>();

            foreach (int x in firstItemCandidates)
            {
                var leqRange = getRange(x, k);
                var leqSolutions = getSolutions(n - 1, k, leqRange);//

                var modRange = getRange(lbound, ubound).Where(m => x % m != 0);
                var modRangeToScan = modRange.Except(leqSolutions.Select(s => s.First).Distinct());
                var modSolutions = getSolutions(n - 1, k, modRangeToScan);

                var allSolutions = leqSolutions.Concat(modSolutions).GroupBy(sol => sol.First, sol => sol.First).Select(g => new SolutionInfo(g.Key, g.Sum()));

                solutions.Add(new SolutionInfo(x, allSolutions.Count()));
            }

            return solutions;

        }


        public IEnumerable<int> getRange(int lbound, int ubound)
        {
            var size = ubound - lbound + 1;
            var range = new int[size];

            for(int i = 0; i< size; i++)
            {
                range[i] = lbound + i;
            }

            return range;
        }
    }
}
