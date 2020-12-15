using System;
using System.Threading;
namespace PacktLibrary
{
    public static class Square
    {
        public static double Squares<T>(T input)
        where T : IConvertible
        {
            double d = input.ToDouble(Thread.CurrentThread.CurrentCulture);
            return d * d;
        }
    }
}