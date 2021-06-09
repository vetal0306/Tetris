using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    static class Field
    {
        public static int Widht
        {
            get 
            {
                return _widht;
            }
            set
            {
                _widht = value;
                Console.SetWindowSize(_widht, Field.Height);
                Console.SetBufferSize(_widht, Field.Height);
            }
        }

        public static int Height
        {
            get 
            {
                return _heiht;
            }
            set
            {
                _heiht = value;
                Console.SetWindowSize(value, Field.Height);
                Console.SetBufferSize(value, Field.Height);
            }
        }


        private static int _widht = 20;
        private static int _heiht = 20;

        public static int GetWidht()
        {
            return _widht;
        }

        internal static void SetWidht(int value)
        {
            _widht = value;
            Console.SetWindowSize(_widht, Field._heiht);
            Console.SetBufferSize(_widht, Field._heiht);
        }

        public static void TryDeleteLines()
        {
            for (int j = 0; j < Height; j++)
            {
                int counter = 0;

                for (int i = 0; i < Widht; i++)
                {
                    if (_heap[j][i])
                        counter++;
                }
                if (counter == Widht)
                {
                    DeleteLines(j);
                    Redraw();

                }
            }
        }

        private static void DeleteLines(int line)
        {
            for (int j = line; j >= 0; j--)
            {
                for (int i = 0; i < Widht; i++)
                {
                    if (j == 0)
                        _heap[j][i] = false;
                    else
                        _heap[j][i] = _heap[j - 1][i];
                }
            }
        }

        private static void Redraw()
        {
            for(int j = 0; j < Height; j++)
            {
                for (int i = 0; i < Widht; i++)
                {
                    if (_heap[j][i])
                        Drawer.DrawPoint(i, j);
                    else
                        Drawer.DrawPoint(i, j);                            
                }
            }
        }

        private static bool[][] _heap;

        static Field()
        {
            _heap = new bool[Height][];
            for (int i = 0; i < Height; i++)
            {
                _heap[i] = new bool[Widht];
            }
        }

        public static bool CheckStrike(Point p)
        {
            return _heap[p.Y][p.X];
        }


        public static void AddFigure(Figure fig) 
        {
            foreach (var p in fig.Points)
            {
                _heap[p.Y][p.X] = true;
            }
        }
    }
}
