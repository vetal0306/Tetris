using System;
using Tetris;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num1 = new int[5];
            num1[0] = 1;
            num1[2] = 6;

            
            //foreach(int i in num1)
            //{
            //   Console.WriteLine(i);
            //}

            Point[] points = new Point[3];
            points[0] = new Point(1, 2, '#');
            points[1] = new Point(4, 2, '#');
            points[2] = new Point(1, 3, '#');

            foreach (Point p in points)
            {
                p.Draw();
            }

            Console.ReadLine();
        }
    }
}
