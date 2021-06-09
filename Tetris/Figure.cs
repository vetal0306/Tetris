using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    abstract class Figure
    {
        const int LENGHT = 4;
        protected Point[] points = new Point[LENGHT];



        public void Draw()
        {
            foreach (Point p in points)
            {
                p.Draw();
            }
        }

        internal void TryMove(Direction dir)
        {
            Hide();
            var clone = Clone();
            Move(clone, dir);
            if (VerifyPosition(clone))
                points = clone;

            Draw();
        }

        private bool VerifyPosition(Point[] plist)
        {
            foreach (var p in plist)
            {
                if (p.X < 0 || p.Y < 0 || p.X >= Field.Widht || p.Y >= Field.HEIGHT)
                    return false;
            }

            return true;
        }

        private Point[] Clone()
        {
            var newPoint = new Point[LENGHT];
            for (int i = 0; i < LENGHT; i++) 
            {
                newPoint[i] = new Point(points[i]);
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
            foreach (Point p in points)
            {
                p.Hide();
            }
        }

        internal void TryRotate()
        {
            Hide();
            var clone = Clone();
            Rotate(clone);
            if (VerifyPosition(clone))
                points = clone;

            Draw();
        }

        public abstract void Rotate(Point[] plist);

        
    }
}
