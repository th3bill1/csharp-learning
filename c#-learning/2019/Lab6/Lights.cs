using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharplearning._2019.Lab6
{
    public struct Vector
    {
        public const int TypeVector = 0;
        public const int TypeColour = 1;
        private readonly int type;
        private float x;
        private float y;
        private float z;
        public float X
        {
            readonly get => x;
            set
            {
                if (type == TypeColour)
                    x = Math.Clamp(value, 0, 1);
                else x = value;
            }
        }
        public float Y
        {
            readonly get => y;
            set
            {
                if (type == TypeColour)
                    y = Math.Clamp(value, 0, 1);
                else y = value;
            }
        }
        public float Z
        {
            readonly get => z;
            set
            {
                if (type == TypeColour)
                    z = Math.Clamp(value, 0, 1);
                else z = value;
            }
        }
        public readonly float Length => (float)Math.Sqrt(x * x + y * y + z * z);
        public Vector(float x, float y, float z, int type = TypeVector)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.type = type;
        }
        public readonly void Deconstruct(out float _x, out float _y, out float _z) => (_x, _y, _z) = (x, y, z);
        public static float Dot(Vector a, Vector b) => a.x * b.x + a.y * b.y + a.z * b.z;
        public static Vector Subtract(Vector a, Vector b) => new(a.x - b.x, a.y - b.y, a.z - b.z);
        public static Vector Multiply(Vector a, Vector b) => new(a.x * b.x, a.y * b.y, a.z * b.z);
        public static Vector Multiply(float a, Vector b) => new(a * b.x, a * b.y, a * b.z);
        public override readonly string ToString() => $"[{x,6:0.00}, {y,6:0.00}, {z,6:0.00}]";
    }
    abstract class Light
    {
        public float Intensity { get; set; }
        public Vector Colour { get; set; }
        public abstract Vector Compute(Lab6.Surface surface);
        public Light(float intensity, Vector colour)
        {
            Intensity = intensity;
            Colour = colour;
        }
    }
    class DirectionalLight : Light
    {
        public Vector Direction { get; set; }
        public DirectionalLight(float intensity, Vector colour, Vector direction) : base(intensity, colour) => Direction = direction;
        public override Vector Compute(Lab6.Surface surface) => Vector.Multiply(Vector.Dot(Direction, surface.Normal), Vector.Multiply(Intensity, Vector.Multiply(Colour, surface.Colour)));
    }
    class PointLight : Light
    {
        public Vector Location { get; set; }
        public float Range { get; set; }
        public PointLight(float intensity, Vector colour, Vector location, float range) : base(intensity, colour)
        {
            Location = location;
            Range = range;
        }
        public bool IsInRange(Lab6.Surface surface, out Vector location, out float distance)
        {
            location = Vector.Subtract(Location, surface.Location);
            distance = location.Length;
            return distance <= Range;
        }
        public override Vector Compute(Lab6.Surface surface)
        {
            if (IsInRange(surface, out Vector direction, out float distance))
            {
                float lightCoefficient = Vector.Dot(direction, surface.Normal);
                float effectiveIntensity = Intensity * (1.0f - distance / Range);
                return Vector.Multiply(effectiveIntensity, Vector.Multiply(lightCoefficient, Vector.Multiply(Colour, surface.Colour)));
            }
            else return surface.Colour;
        }
    }
}