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

            FigureGenerator generator = new FigureGenerator(20, 0, '*');
            Figure s = null;
            while (true)
            {                
                FigureFall(out s, generator);
            }          
            
        }
        static void FigureFall(out Figure fig, FigureGenerator generator)
        {
            fig = generator.GetNewFigure();
            fig.Draw();

            for (int i = 0; i < 15; i++)
            {
                fig.Hide();
                fig.Move(Direction.DOWN);
                fig.Draw();
                Thread.Sleep(1000);
            }
        }
    }
}
