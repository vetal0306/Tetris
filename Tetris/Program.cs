using System;
using System.Threading;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);
            #region
            //Figure[] f = new Figure[2]; // отримуємо фігури за допомогою класу Figure який наслідують Square, Stick
            //f[0] = new Square(2, 5, '*');
            //f[1] = new Stick(4, 7, '|');
            //foreach (Figure fig in f)
            //{
            //    fig.Draw();
            //}
            #endregion

            Square s = new Square(2, 5, '*'); //квадрат з точок '*'
            s.Draw();

            Thread.Sleep(1000);
            s.Hide();
            s.Move(Direction.RIGHT);
            s.Draw();

            Thread.Sleep(1000);
            s.Hide();
            s.Move(Direction.DOWN);
            s.Draw();
            Thread.Sleep(1000);
            s.Hide();
            s.Move(Direction.DOWN);
            s.Draw();

            Thread.Sleep(1000);
            s.Hide();
            s.Move(Direction.LEFT);
            s.Draw();

            //Stick k = new Stick(4, 7, '$'); // полоска з символів '$'
            //k.Draw();

            //Point p1 = new Point(2, 3, '*');            
            //p1.Draw();

            //Point p2 = new Point()
            //{
            //  x = 4,
            // y = 5,
            //c = '#'
            //};

            //p2.Draw();

        }
    }
}
