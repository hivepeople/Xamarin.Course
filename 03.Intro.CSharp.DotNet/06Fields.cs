namespace Xamarin.Course.Intro.CSharp.DotNet
{
    namespace Fields
    {
        public sealed class Coordinate
        {
            public static readonly Coordinate Origin =
                new Coordinate(0, 0);

            private readonly int x;
            private readonly int y;

            public Coordinate(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public int X { get { return this.x;} }

            public int Y { get { return this.y; } }
        }
    }
}
