using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.SecondTask
{
    public interface IRemoteControlCar : FirstTask.IVehicle
    {
        public int Fuel { get; }
        public int DistanceTravelled { get; set; }
    }
}
