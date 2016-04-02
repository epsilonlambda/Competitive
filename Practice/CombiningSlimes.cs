using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonLambda.Competitive.TopCoder.Practice
{
    public class CombiningSlimes
    {
        public int maxMascots(int[] a)
        {
            var slimes = new List<int>(a);

            int score = 0;
            while(slimes.Count > 1)
            {
                var first = slimes.Pop();
                var second = slimes.Pop();

                slimes.Add(first + second);

                score += (first * second);
            }

            return score;

        }
    }

    public static class ListExtension
    {
        public static T Pop<T>(this List<T> lst)
        {
            var x = lst.First();
            lst.RemoveAt(0);
            return x;
        }
    }
}
