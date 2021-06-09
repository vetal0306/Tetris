using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    abstract class Figure
    {
        const int LENGHT = 4;
        public Point[] Points = new Point[LENGHT];



        public void Draw()
        {
            foreach (Point p in Points)
            {
                p.Draw();
            }
        }

        internal Result TryMove(Direction dir)
        {
            Hide();
            var clone = Clone();
            Move(clone, dir);
            var result = VerityPosition(clone);
            if (result == Result.Success)
                Points = clone;

            Draw();
            return result;
        }

        private Result VerityPosition(Point[] newPoints)
        {
            foreach (var p in newPoints)
            {
                if (p.Y >= Field.Height)
                    return Result.Down_Border_Strike;
                if (p.X >= Field.Widht || p.X <= 0 || p.Y <= 0)
                    return Result.Border_Strike;
                if (CheckStrike(p))
                    return Result.Heap_Strike;
            }
            return Result.Success;           
        }

        private Point[] Clone()
        {
            var newPoint = new Point[LENGHT];
            for (int i = 0; i < LENGHT; i++) 
            {
                newPoint[i] = new Point(Points[i]);
            }
            return newPoint;

        }

        public void Move(Point[] plist, Direction dir)
        {
            foreach (var p in plist)
            {
                p.Move(dir);
            }
        }

        //public void Move(Direction dir)
        //{
        //    Hide();
        //    foreach(Point p in points)
        //    {
        //        p.Move(dir);
        //    }
        //    Draw();
        //}

        public void Hide()
        {
            foreach (Point p in Points)
            {
                p.Hide();
            }
        }

        internal Result TryRotate()
        {
            Hide();
            var clone = Clone();
            Rotate(clone);

            var result = VerityPosition(clone);
            if (result == Result.Success)
                Points = clone;

            Draw();
            return result;
        }

        public abstract void Rotate(Point[] plist);

        
    }
}
