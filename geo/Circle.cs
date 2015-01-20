
using Delaunay.geo;
using System;

namespace Delaunay
{	
	namespace Geo
	{
		public sealed class Circle
		{
			public Point center;
			public float radius;
		
			public Circle (float centerX, float centerY, float radius)
			{
				this.center = new Point (centerX, centerY);
				this.radius = radius;
			}
		
			public override string ToString ()
			{
				return "Circle (center: " + center.ToString () + "; radius: " + radius.ToString () + ")";
			}

		}
	}
}