using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.FirstTask
{
    public interface IVehicle
    {
        public void Drive(int length);
        public bool Refuel(int amount);
    }
}
