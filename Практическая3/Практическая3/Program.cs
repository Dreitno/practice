using System;

namespace PointClass
{
    class Point
    {
        private int x;
        private int y;

        public Point()
        {
            x = 0;
            y = 0;
        }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public void PrintCoordinates()
        {
            Console.WriteLine($"Координаты точки: ({x}, {y})");
        }

        public double DistanceToOrigin()
        {
            return Math.Sqrt(x * x + y * y);
        }

        public void Move(int a, int b)
        {
            x += a;
            y += b;
        }

        public int MultiplyScalar
        {
            set
            {
                x *= value;
                y *= value;
            }
        }

        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return x;
                    case 1: return y;
                    default: throw new IndexOutOfRangeException("Индекс может быть только 0 или 1");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    default: throw new IndexOutOfRangeException("Индекс может быть только 0 или 1");
                }
            }
        }

        public static Point operator ++(Point p)
        {
            p.x++;
            p.y++;
            return p;
        }

        public static Point operator --(Point p)
        {
            p.x--;
            p.y--;
            return p;
        }

        public static bool operator true(Point p)
        {
            return p.x == p.y;
        }

        public static bool operator false(Point p)
        {
            return p.x != p.y;
        }

        public static Point operator +(Point p, int scalar)
        {
            return new Point(p.x + scalar, p.y + scalar);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point();
            p1.PrintCoordinates();

            Point p2 = new Point(3, 4);
            p2.PrintCoordinates();

            Console.WriteLine($"Расстояние до начала координат: {p2.DistanceToOrigin()}");

            p2.Move(2, -1);
            p2.PrintCoordinates();

            Console.WriteLine($"Координата X через индексатор: {p2[0]}");
            Console.WriteLine($"Координата Y через индексатор: {p2[1]}");

            p2.MultiplyScalar = 2;
            p2.PrintCoordinates();

            p2++;
            p2.PrintCoordinates();

            if (p2)
                Console.WriteLine("Координаты X и Y равны");
            else
                Console.WriteLine("Координаты X и Y не равны");

            Point p3 = p2 + 5;
            p3.PrintCoordinates();
        }
    }
}