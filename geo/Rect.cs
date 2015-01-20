using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delaunay.geo
{
    public struct Rect
    {
        public float x;
        public float y;
        public float width;
        public float height;

        public Rect(float x, float y, float width, float height)
        {
            // TODO: Complete member initialization
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public float xMin
        {
            get { return x; }

        }

        public float xMax
        {
            get { return x + width; }
        }

        public float yMin
        {
            get { return y; }

        }

        public float yMax
        {
            get { return y + height; }
        }

    }
}
