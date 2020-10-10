using System;
using System.Threading;

namespace loading_bar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("[");
            Console.CursorLeft += 10;
            Console.Write("]");
            Console.CursorLeft = 1;
            for (int i = 0; i < 10; ++i)
            {
                Thread.Sleep(500);
                if (i == 8)
                    Console.Write('*');
                else
                    Console.Write('|');
            }
        }
    }
}