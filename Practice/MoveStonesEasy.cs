using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonLambda.Competitive.TopCoder.Practice
{
    public class MoveStonesEasy
    {
        public int get(int[] a, int[] b)
        {
            int nPiles = a.Length;
            int moves = 0;
            for(int currentFixCandidate = 0; currentFixCandidate < nPiles; currentFixCandidate++)
            {
                var extras = a[currentFixCandidate] - b[currentFixCandidate];
                if (extras >= 0) continue;

                System.Diagnostics.Debug.Assert(extras < 0);
                var required = Math.Abs(extras);

                var searchDistance = 0;
                while (required > 0)
                {
                    var nextExtraSourceIndex = GetExtraSourceIndex(currentFixCandidate, a, b, searchDistance);
                    if (nextExtraSourceIndex < 0) return -1;
                    searchDistance = Math.Abs(currentFixCandidate - nextExtraSourceIndex);

                    var extraAvailable = a[nextExtraSourceIndex] - b[nextExtraSourceIndex];

                    var transferCount = Math.Min(required, extraAvailable);
                    var transferDistance = Math.Abs(currentFixCandidate - nextExtraSourceIndex);
                    a[nextExtraSourceIndex] -= transferCount;
                    a[currentFixCandidate] += transferCount;
                    moves += (transferCount * transferDistance);
                    required -= transferCount;
                }
            }

            return moves;
        }

        internal int GetExtraSourceIndex(int currentFixCandidate, int[] a, int[] b, int searchStartDistance = 0)
        {
            int maxDistance = Math.Max(currentFixCandidate, a.Length - currentFixCandidate - 1);
            for(int distance = 1; distance <= maxDistance; distance++)
            {
                int leftChoice = currentFixCandidate - distance;
                int rightChoice = currentFixCandidate + distance; // right, not necessarily correct...

                var choices = new int[] { leftChoice, rightChoice }.Where(candidate => HasExtras(candidate, a, b));
                if (choices.Any())
                    return choices.First();
            }

            return -1;
        }

        internal bool HasExtras(int i, int[] a, int[] b)
        {
            return (i >= 0 && i < a.Length)
                && (a[i] - b[i] > 0);
        }
    }
}
