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


        private static int _widht = 40;
        private static int _heiht = 30;

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
    }
}
