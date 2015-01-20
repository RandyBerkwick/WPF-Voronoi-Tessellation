
using Delaunay.geo;
using System;
using System.Collections.Generic;


namespace Delaunay
{
	namespace Geo
	{
		public sealed class Polygon
		{
			private List<Point> _vertices;

			public Polygon (List<Point> vertices)
			{
				_vertices = vertices;
			}

			public float Area ()
			{
				return (float)Math.Abs (SignedDoubleArea () * 0.5f); // XXX: I'm a bit nervous about this; not sure what the * 0.5 is for, bithacking?
			}

			public Winding Winding ()
			{
				float signedDoubleArea = SignedDoubleArea ();
				if (signedDoubleArea < 0) {
					return Geo.Winding.CLOCKWISE;
				}
				if (signedDoubleArea > 0) {
					return Geo.Winding.COUNTERCLOCKWISE;
				}
				return Geo.Winding.NONE;
			}

			private float SignedDoubleArea () // XXX: I'm a bit nervous about this because Actionscript represents everything as doubles, not floats
			{
				int index, nextIndex;
				int n = _vertices.Count;
				Point point, next;
				float signedDoubleArea = 0; // Losing lots of precision?
				for (index = 0; index < n; ++index) {
					nextIndex = (index + 1) % n;
					point = _vertices [index];
					next = _vertices [nextIndex];
					signedDoubleArea += point.x * next.y - next.x * point.y;
				}
				return signedDoubleArea;
			}
		}
	}
}