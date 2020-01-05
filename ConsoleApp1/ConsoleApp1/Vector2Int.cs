using System;

namespace ConsoleApp1
{
    public struct Vector2Int : IEquatable<Vector2Int>
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Vector2Int(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Vector2Int other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }
    }
}