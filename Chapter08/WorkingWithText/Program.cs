using System;
using static System.Console;

namespace WorkingWithText
{
    class Program
    {
        static void Main(string[] args)
        {
            string films = "\"Monsters, Inc.\",\"I, Tonya\",\"Lock, Stock and Two Smoking Barrels\"";
            string[] filmsDumb = films.Split(',');
            WriteLine("Dumb attempt at splitting:"); foreach (string film in filmsDumb)
            {
                WriteLine(film);
            }
        }
    }
}
