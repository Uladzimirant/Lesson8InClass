using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.SecondTask
{
    public class ProductionRemoteControlCar : RemoteControlCar, IComparable<ProductionRemoteControlCar>
    {
        public int NumberOfVictories { get; private set; }


        public ProductionRemoteControlCar(int fuel, int consumption) : base(fuel, consumption)
        {
            NumberOfVictories = 0;
        }


        public int CompareTo(ProductionRemoteControlCar? other)
        {
            return NumberOfVictories.CompareTo(other?.NumberOfVictories) ;
        }


        public void RegisterVictory()
        {
            NumberOfVictories++;
        }

        public override string? ToString()
        {
            return base.ToString()?.TrimEnd(')') + $", Victories: {NumberOfVictories})";
        }
    }
}
