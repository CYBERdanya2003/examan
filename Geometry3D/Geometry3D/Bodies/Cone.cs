using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry3D
{
    public class Cone : Body
    {
        public double Radius { get; }
        public double SizeZ { get; }

        public Cone(Vector3 position, double radius, double sizeZ) : base(position)
        {
            Radius = radius;
            SizeZ = sizeZ;
        }

        public override bool ContainsPoint(Vector3 point)
        {
            var vectorX = point.X - Position.X;
            var vectorY = point.Y - Position.Y;
            var length2 = vectorX * vectorX + vectorY * vectorY;
            var minZ = Position.Z - SizeZ / 2;
            var maxZ = minZ + SizeZ;
            if (point.Z < minZ || point.Z > maxZ)
                return false;
            var angle = Math.Atan2(Radius, SizeZ / 2);
            var height = Math.Abs(point.Z - Position.Z);
            var sectionRadius = height * Math.Tan(angle);
            return length2 <= sectionRadius * sectionRadius;
        }

        public override RectangularCuboid GetBoundingBox()
        {
            var boundingBox = new RectangularCuboid(Position, 0, 0, 0);
            boundingBox.SizeX = 2 * Radius;
            boundingBox.SizeY = 2 * Radius;
            boundingBox.SizeZ = SizeZ;
            return boundingBox;
        }
    }
}
