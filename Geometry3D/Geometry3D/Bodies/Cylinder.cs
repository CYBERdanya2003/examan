using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry3D
{
    public class Cylinder : Body
    {
        public double SizeZ { get; }

        public double Radius { get; }

        public Cylinder(Vector3 position, double sizeZ, double radius) : base(position)
        {
            SizeZ = sizeZ;
            Radius = radius;
        }

        public override bool ContainsPoint(Vector3 point)
        {
            var vectorX = point.X - Position.X;
            var vectorY = point.Y - Position.Y;
            var length2 = vectorX * vectorX + vectorY * vectorY;
            var minZ = Position.Z - SizeZ / 2;
            var maxZ = minZ + SizeZ;
            return length2 <= Radius * Radius && point.Z >= minZ && point.Z <= maxZ;
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
