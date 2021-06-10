﻿using System;
using System.Threading;
using System.Timers;

namespace Tetris
{
    class Program
    {
        const int TIMER_INTERVAL = 500;
        static System.Timers.Timer timer;

        static private Object _lockObject = new object();

        static Figure currentFigure;
        static FigureGenerator generator;

        private static void SetTimer()
        {
            timer = new System.Timers.Timer(TIMER_INTERVAL);            
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Monitor.Enter(_lockObject);
            var result = currentFigure.TryMove(Direction.DOWN);
            ProcessResult(result, ref currentFigure);
            Monitor.Exit(_lockObject);

        }

        private static void Test()
        {
            DrawerProvider.Drawer.DrawPoint(5, 6);
        }

        static void Main(string[] args)
        {
            DrawerProvider.Drawer.InitField();       
                      


            
            generator = new FigureGenerator(Field.Widht / 2, 0);
            Figure currentFigure = generator.GetNewFigure();

            while (true) 
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    Monitor.Enter(_lockObject);
                    var result = HandleKey(currentFigure, key.Key);
                    ProcessResult(result, ref currentFigure);
                    Monitor.Exit(_lockObject);
                }
            }
            
        }

        private static bool ProcessResult(Result result, ref  Figure currentFigure)
        {
            if (result == Result.Heap_Strike || result == Result.Down_Border_Strike)
            {
                Field.AddFigure(currentFigure);
                Field.TryDeleteLines();

                if(currentFigure.IsOnTop())
                {
                    DrawerProvider.Drawer.WriteGameOver();
                    
                    timer.Elapsed -= OnTimedEvent;
                    return true;
                }
                else
                {
                    currentFigure = generator.GetNewFigure();
                    return false;
                }

                
            }
            else
                return false;
        }

        
        private static Result HandleKey(Figure f, ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    return f.TryMove(Direction.LEFT);  
                    
                case ConsoleKey.RightArrow:
                    return f.TryMove(Direction.RIGHT);
                    
                case ConsoleKey.DownArrow:
                    return f.TryMove(Direction.DOWN);
                    
                case ConsoleKey.Spacebar:
                    return f.TryRotate();
                    
            }
            return Result.Success;

        }
    }
}
