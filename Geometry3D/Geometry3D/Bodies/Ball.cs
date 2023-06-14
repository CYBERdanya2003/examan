using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry3D
{
    public class Ball : Body
    {
        public double Radius { get; }

        public Ball(Vector3 position, double radius) : base(position)
        {
            Radius = radius;
        }

        public override bool ContainsPoint(Vector3 point)
        {
            var vector = point - Position;
            var length2 = vector.GetLength2();
            return length2 <= Radius * Radius;
        }

        public override RectangularCuboid GetBoundingBox()
        {
            var boundingBox = new RectangularCuboid(Position, 0, 0, 0);
            boundingBox.SizeX = 2 * Radius;
            boundingBox.SizeY = 2 * Radius;
            boundingBox.SizeZ = 2 * Radius;
            return boundingBox;
        }
    }

}
