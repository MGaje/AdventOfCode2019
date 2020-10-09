using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AoC.Day1
{
    public static class Entry
    {
        public static void Run()
        {
            var input = File.ReadAllLines(@"Day1/input.txt");
            var fuel = new List<string>(input).Select(x => new Day1.Classes.Module(Convert.ToInt32(x)).GetFuel()).Sum();

            Console.WriteLine("Fuel: " + fuel);
        }
    }
}
