using System;
using System.Linq;

namespace EpsilonLambda.Competitive.TopCoder.Practice
{
    public class SegmentsAndPoints
    {
        String isPossible(int[] p, int[] l, int[] r)
        {
            Array.Sort(p);
            var segments = l.Zip(r, (left, right) => new Tuple<int, int>(left, right)).OrderBy(seg => seg.Item2).ToList();

            foreach(int point in p)
            {
                int found = -1;
                for(int i = 0; i < segments.Count; i++)
                {
                    var seg = segments[i];
                    if(seg.Item1 <= point && seg.Item2 >= point)
                    {
                        found = i;
                        break;
                    }
                }

                if(found == -1)
                {
                    return "Impossible";
                }

                segments.RemoveAt(found);
            }

            return "Possible";
        }
    }
}
