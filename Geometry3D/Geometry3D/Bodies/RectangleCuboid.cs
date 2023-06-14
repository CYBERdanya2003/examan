using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry3D
{
    public class RectangularCuboid : Body
    {
        public double SizeX { get; set; }
        public double SizeY { get; set; }
        public double SizeZ { get; set; }

        public RectangularCuboid(Vector3 position, double sizeX, double sizeY, double sizeZ) : base(position)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            SizeZ = sizeZ;
        }

        public override bool ContainsPoint(Vector3 point)
        {
            var minPoint = new Vector3(
                Position.X - SizeX / 2,
                Position.Y - SizeY / 2,
                Position.Z - SizeZ / 2);
            var maxPoint = new Vector3(
                Position.X + SizeX / 2,
                Position.Y + SizeY / 2,
                Position.Z + SizeZ / 2);
            return point >= minPoint && point <= maxPoint;
        }

        public override RectangularCuboid GetBoundingBox()
        {
            return new RectangularCuboid(Position, SizeX, SizeY, SizeZ);
        }

    }

}
