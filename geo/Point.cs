using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delaunay.geo
{
    public struct Point : IEquatable<Point>
    {
        public float x;
        public float y;

        public Point(float x, float y)
        {
            this.x = x;
            this.y = x;
        }


        public static float Distance(Point p0, Point p1)
        {
            float dx = p0.x - p1.x;
            float dy = p0.y - p1.y;

            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        public static readonly Point zero = new Point(0, 0);

        public bool Equals(Point other)
        {
            return this.x == other.x && this.y == other.y;
        }


        public override bool Equals(object obj)
        {
            if (!(obj is Point))
                return false;

            return this.Equals((Point)obj);
        }


        public override int GetHashCode()
        {
            return unchecked(x.GetHashCode() + y.GetHashCode());
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return !p1.Equals(p2);
        }

    }
}
