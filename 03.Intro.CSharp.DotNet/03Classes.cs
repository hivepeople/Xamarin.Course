namespace Xamarin.Course.Intro.CSharp.DotNet
{
    namespace Classes
    {
        public class Vector2D
        {
            public float x, y;

            public Vector2D(float x, float y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public class Usage
        {
            public void Main()
            {
                Vector2D v1 = new Vector2D(1, 0);
                Vector2D v2 = new Vector2D(0, 1);

                // vector addition
                v1.x += v2.x;
                v1.y += v2.y;

                System.Console.WriteLine("v1 = (" + v1.x + ", " + v1.y + ")");
            }
        }
    }
}
