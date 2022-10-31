using ConsoleApp1.FirstTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.SecondTask
{
    public abstract class RemoteControlCar : Car, IRemoteControlCar
    {
        private int _distanceTravelled;
        public int DistanceTravelled { 
            get
            {
                return _distanceTravelled;
            } 
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), value, "Must be positive");
                _distanceTravelled = value;
            }
        }

        
        public RemoteControlCar(int fuel, int consumption) : base(fuel, consumption)
        {
            DistanceTravelled = 0;
        }


        public override void Drive(int length)
        {
            DistanceTravelled += Fuel >= Consumption * length ? length : 0;
            base.Drive(length);
        }

        public override string? ToString()
        {
            return base.ToString()?.TrimEnd(')') + $", Distance: {DistanceTravelled})";
        }
    }
}
