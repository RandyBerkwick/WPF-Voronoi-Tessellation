using System;
using System.Windows;
using Delaunay;

namespace Delaunay.Geo
{

    public sealed class Circle
    {
        public Point center;
        public double  radius;

        public Circle(double  centerX, double  centerY, double  radius)
        {
            this.center = new Point(centerX, centerY);
            this.radius = radius;
        }

        public override string ToString()
        {
            return "Circle (center: " + center.ToString() + "; radius: " + radius.ToString() + ")";
        }

    }
}