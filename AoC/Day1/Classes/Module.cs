using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Day1.Classes
{
    class Module : IModule
    {
        public Module(int mass)
        {
            Mass = mass;
        }

        public int Mass { get; set; }

        public long GetFuel()
        {
            return _GetFuel(Mass);
        }

        private int _GetFuel(int input)
        {
            int fuel = Convert.ToInt32(Math.Round(Math.Floor((decimal)input / 3))) - 2;

            if (fuel <= 0)
            {
                return 0;
            }

            
            return fuel + _GetFuel(fuel);
        }
    }
}
