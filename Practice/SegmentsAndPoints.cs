using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonLambda.Competitive.TopCoder.Practice
{
    public class SegmentsAndPoints
    {
        public string isPossible(int[] p, int[] l, int[] r)
        {
            int n = p.Length;

            IEnumerable<Point> allPoints = p.Select((x, id) => new Point(Point.PType.POINT, x, id));
            allPoints = allPoints.Concat(l.Select((x,id) => new Point(Point.PType.LEFT, x,id)));
            allPoints = allPoints.Concat(r.Select((x,id) => new Point(Point.PType.RIGHT, x,id)));

            allPoints = allPoints.OrderBy(x => x.Location);

            var intervalSet = new HashSet<int>();
            var pointToIntervals = new Dictionary<int, List<int>>();

            foreach(var point in allPoints)
            {
                if(point.PointType == Point.PType.LEFT)
                {
                    intervalSet.Add(point.ID);
                }
                else if(point.PointType == Point.PType.RIGHT)
                {
                    intervalSet.Remove(point.ID);
                }
                else
                {
                    pointToIntervals[point.ID] = new HashSet<int>(intervalSet);
                }
            }





 

        }

        class Point
        {
            public enum PType { LEFT, RIGHT, POINT }
            public PType PointType;
            public int Location;
            public int ID;

            public Point(PType type, int location, int id)
            {
                PointType = type;
                Location = location;
                ID = id;
            }
        }
    }
}
