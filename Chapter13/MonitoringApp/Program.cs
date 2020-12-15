using System;
using MonitoringLib;
using System.Linq;
using static System.Console;

namespace MonitoringApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //WriteLine("Processing. Please wait...");
            //Recorder.Start();
            //int[] largeArrayOfInts = Enumerable.Range(1, 100_000).ToArray();
            //System.Threading.Thread.Sleep(new Random().Next(5, 10) * 1000);
            //Recorder.Stop();
            int[] numbers = Enumerable.Range(1, 50_000).ToArray();
            WriteLine("Using string with +"); Recorder.Start();
            string s = ""; for (int i = 0; i < numbers.Length; i++)
            {
                s += numbers[i] + ", ";
            }

            Recorder.Stop();
            WriteLine("Using StringBuilder");
            Recorder.Start();
            var builder = new System.Text.StringBuilder();
            for (int i = 0; i < numbers.Length; i++)
            {
                builder.Append(numbers[i]); builder.Append(", ");
            }
            Recorder.Stop();
        }
    }
}