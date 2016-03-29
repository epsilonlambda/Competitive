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
            int moves = 0;
            for (int i = 0; i < a.Length - 1; i++)
            {
                int delta = a[i] - b[i];
                if(delta != 0)
                {
                    a[i] -= delta;
                    a[i + 1] += delta;
                    moves += Math.Abs(delta);
                }
            }

            if (a.Last() != b.Last())
                return -1;
            else
                return moves;
        }
    }
}
