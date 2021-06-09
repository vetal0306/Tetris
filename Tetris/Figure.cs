﻿using System;
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
            
            Move(dir);

            var result = VerityPosition();
            if (result != Result.Success)
                Move(Reverse(dir));

            Draw();
            return result;
        }

        private Result VerityPosition()
        {
            foreach (var p in Points)
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

        private bool CheckStrike(Point p)
        {
            throw new NotImplementedException();
        }

        public void Move(Direction dir)
        {
            foreach (var p in Points)
            {
                p.Move(dir);
            }
        }

        private Direction Reverse(Direction dir)
        {
            switch(dir)
            {
                case Direction.LEFT:
                    return Direction.RIGHT;
                case Direction.RIGHT:
                    return Direction.LEFT;
                case Direction.DOWN:
                    return Direction.UP;
                case Direction.UP:
                    return Direction.DOWN;
            }
            return dir;
        }

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
            Rotate();

            var result = VerityPosition();
            if (result != Result.Success)
                Rotate();

            Draw();
            return result;
        }

        internal bool IsOnTop()
        {
            return Points[0].Y == 0;
        }

        public abstract void Rotate();

        
    }
}
