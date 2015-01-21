using System;
using System.Windows;
using Delaunay;

namespace Delaunay.Geo
{
    public sealed class LineSegment
    {
        public static int CompareLengths_MAX(LineSegment segment0, LineSegment segment1)
        {
            double  length0 = DelaunayHelpers.Distance((Point)segment0.p0, (Point)segment0.p1);
            double length1 = DelaunayHelpers.Distance((Point)segment1.p0, (Point)segment1.p1);
            if (length0 < length1)
            {
                return 1;
            }
            if (length0 > length1)
            {
                return -1;
            }
            return 0;
        }

        public static int CompareLengths(LineSegment edge0, LineSegment edge1)
        {
            return -CompareLengths_MAX(edge0, edge1);
        }

        public Nullable<Point> p0;
        public Nullable<Point> p1;

        public LineSegment(Nullable<Point> p0, Nullable<Point> p1)
        {
            this.p0 = p0;
            this.p1 = p1;
        }

    }
}