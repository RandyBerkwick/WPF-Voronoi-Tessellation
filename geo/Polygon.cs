using System;
using System.Collections.Generic;
using System.Windows;


namespace Delaunay.Geo
{
    public sealed class Polygon
    {
        private List<Point> _vertices;

        public Polygon(List<Point> vertices)
        {
            _vertices = vertices;
        }

        public double Area()
        {
            return Math.Abs(SignedDoubleArea() * 0.5f); // XXX: I'm a bit nervous about this; not sure what the * 0.5 is for, bithacking?
        }

        public Winding Winding()
        {
            double signedDoubleArea = SignedDoubleArea();
            if (signedDoubleArea < 0)
            {
                return Geo.Winding.CLOCKWISE;
            }
            if (signedDoubleArea > 0)
            {
                return Geo.Winding.COUNTERCLOCKWISE;
            }
            return Geo.Winding.NONE;
        }

        private double SignedDoubleArea() // XXX: I'm a bit nervous about this because Actionscript represents everything as doubles, not doubles 
        {
            int index, nextIndex;
            int n = _vertices.Count;
            Point point, next;
            double signedDoubleArea = 0; // Losing lots of precision?
            for (index = 0; index < n; ++index)
            {
                nextIndex = (index + 1) % n;
                point = _vertices[index];
                next = _vertices[nextIndex];
                signedDoubleArea += point.X * next.Y - next.X * point.Y;
            }
            return signedDoubleArea;
        }
    }
}