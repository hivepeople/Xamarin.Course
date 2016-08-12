namespace Xamarin.Course.Intro.CSharp.DotNet
{
    namespace Encapsulation
    {
        public class Vector2D
        {
            private float x, y;

            public Vector2D(float x, float y)
            {
                this.x = x;
                this.y = y;
            }

            public void Add(Vector2D other)
            {
                this.x += other.x;
                this.y += other.y;
            }
        }

        public class Usage
        {
            public void Main()
            {
                Vector2D v1 = new Vector2D(1, 0);
                Vector2D v2 = new Vector2D(0, 1);
                v1.Add(v2);  // v1.x is now 1 and v1.y is 1
            }
        }
    }
}
