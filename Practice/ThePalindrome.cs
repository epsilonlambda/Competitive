using System;
using System.Collections.Generic;
using System.Linq;

namespace EpsilonLambda.Competitive.TopCoder.Practice
{
    public class ThePalindrome
    {
        public int find(string s)
        {
            var maxPalindromeSuffix = FindMaxPalindromeSuffix(s);
            return s.Length + s.Length - maxPalindromeSuffix.Length;
        }

        internal string FindMaxPalindromeSuffix(string s)
        {
            if (s == string.Empty)
                return string.Empty;

            var starterPositions = new Queue<int>(FindIndicesOfChar(s.Last(), s));

            int candidateStart = 0;
            int candidateFwPtr = candidateStart;
            int candidateBkPtr = s.Length - 1;

            while (candidateFwPtr < candidateBkPtr)
            {
                if (s[candidateBkPtr] == s[candidateFwPtr])
                {
                    candidateFwPtr++;
                    candidateBkPtr--;
                }
                else
                {
                    ReinitializePointers(ref candidateStart, ref candidateFwPtr, ref candidateBkPtr, starterPositions, s);
                }
            }

            return s.Substring(candidateStart);
        }

        internal void ReinitializePointers(ref int candidateStart,
            ref int candidateFwPtr,
            ref int candidateBkPtr,
            Queue<int> starterPositions,
            string s)
        {
            if (starterPositions.Count == 0)
                throw new Exception();

            candidateStart = starterPositions.Dequeue();
            candidateFwPtr = candidateStart;
            candidateBkPtr = s.Length - 1;
        }

        internal int[] FindIndicesOfChar(char needle, string haystack)
        {
            return haystack.Select((character, index) => new KeyValuePair<char, int>(character, index))
                                                    .Where(kvp => kvp.Key == needle)
                                                    .Select(kvp => kvp.Value).ToArray();

        }

    }
}
