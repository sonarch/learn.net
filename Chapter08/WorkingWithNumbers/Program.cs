using System;
using System.Numerics;
using static System.Console;
namespace WorkingWithNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var largest = ulong.MaxValue;

            Console.WriteLine($"{largest,40:N0}");
        }
    }
}
