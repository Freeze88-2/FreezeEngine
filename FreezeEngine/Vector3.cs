namespace FreezeEngine
{
    public struct Vector3
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public Vector3(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3(int x, int y)
        {
            X = x;
            Y = y;
            Z = 0;
        }

        public override bool Equals(object obj)
        {
            Vector3? cast = (Vector3)obj;
            return cast == this;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Vector3 left, Vector3 right)
        {
            return left.X == right.X && left.Y == right.Y;
        }

        public static bool operator !=(Vector3 left, Vector3 right)
        {
            return left.X != right.X || left.Y != right.Y;
        }

        public static Vector3 operator -(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X - right.X, left.Y - right.Y);
        }
    }
}