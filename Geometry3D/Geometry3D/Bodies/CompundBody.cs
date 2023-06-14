using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry3D
{
    public class CompoundBody : Body
    {
        public IReadOnlyList<Body> Parts { get; }

        public CompoundBody(IReadOnlyList<Body> parts) : base(parts[0].Position)
        {
            Parts = parts;
        }

        public override bool ContainsPoint(Vector3 point)
        {
            if (Parts.Count == 0)
                return false;

            return Parts.Any(body => body.ContainsPoint(point));
        }
        public override RectangularCuboid GetBoundingBox()
        {
            if (Parts.Count == 0)
                return new RectangularCuboid(Position, 0, 0, 0);

            double minX = double.MaxValue;
            double minY = double.MaxValue;
            double minZ = double.MaxValue;
            double maxX = double.MinValue;
            double maxY = double.MinValue;
            double maxZ = double.MinValue;

            foreach (var part in Parts)
            {
                var partBox = part.GetBoundingBox();
                var minPoint = new Vector3(
                    partBox.Position.X - partBox.SizeX / 2,
                    partBox.Position.Y - partBox.SizeY / 2,
                    partBox.Position.Z - partBox.SizeZ / 2);
                var maxPoint = new Vector3(
                    partBox.Position.X + partBox.SizeX / 2,
                    partBox.Position.Y + partBox.SizeY / 2,
                    partBox.Position.Z + partBox.SizeZ / 2);

                if (minPoint.X < minX) minX = minPoint.X;
                if (minPoint.Y < minY) minY = minPoint.Y;
                if (minPoint.Z < minZ) minZ = minPoint.Z;
                if (maxPoint.X > maxX) maxX = maxPoint.X;
                if (maxPoint.Y > maxY) maxY = maxPoint.Y;
                if (maxPoint.Z > maxZ) maxZ = maxPoint.Z;
            }

            var centerPoint = new Vector3(
                (minX + maxX) / 2,
                (minY + maxY) / 2,
                (minZ + maxZ) / 2);

            var boundingBox = new RectangularCuboid(centerPoint, 0, 0, 0);
            boundingBox.SizeX = maxX - minX;
            boundingBox.SizeY = maxY - minY;
            boundingBox.SizeZ = maxZ - minZ;

            return boundingBox;
        }
    }
}
