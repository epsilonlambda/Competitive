using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonLambda.Competitive.TopCoder.Practice
{
    public class TreeAndVertex
    {
        public int get(int[] tree)
        {
            var vtxToDegree = new int[tree.Length + 1];
            for(int v = 0; v < tree.Length; v++)
            {
                vtxToDegree[tree[v]]++;
            }

            vtxToDegree[0]--;

            return (vtxToDegree.Max() + 1);
        }
    }
}
