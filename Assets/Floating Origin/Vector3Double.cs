using UnityEngine;

namespace Assets.VampirasuStudios.ScaleSpacewithFloatingOrigin
{
    public struct Vector3Double
    {
        

        public Vector3Double(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public double X;
        public double Y;
        public double Z;  

        public Vector3 AsFloat()
        {
            return new Vector3((float)X, (float)Y, (float)Z);
        }

        public override string ToString() { return "(" + X.ToString("N1") + ", " + Y.ToString("N1") + ", " + Z.ToString("N1") + ")"; }

        public static Vector3Double operator +(Vector3Double a, Vector3 b)
        {
            return new Vector3Double(a.X + b.x, a.Y + b.y, a.Z + b.z);
        }

        public static Vector3Double operator -(Vector3Double a, Vector3 b)
        {
            return new Vector3Double(a.X - b.x, a.Y - b.y, a.Z - b.z);
        }

        public static Vector3Double operator /(Vector3Double a, float b)
        {
            return new Vector3Double(a.X /b, a.Y / b, a.Z / b);
        }

        public static Vector3Double operator *(Vector3Double a, float b)
        {
            return new Vector3Double(a.X * b, a.Y * b, a.Z * b);
        }
    }
}