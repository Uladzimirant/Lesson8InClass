using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.SecondTask
{
    public static class TestTruck
    {
        public static void Race(params IRemoteControlCar[] carsToRace)
        {
            Dictionary<IRemoteControlCar, int> oldDistance = carsToRace.ToDictionary(e => e, e => e.DistanceTravelled);
            foreach (var car in carsToRace)
            {
                int step = 10;
                while (true)
                {
                    int fuel = car.Fuel;
                    car.Drive(step);
                    if (fuel == car.Fuel)
                    {
                        if (step > 1) { step /= 2; } else break;
                    }
                }
            }
            (carsToRace.MaxBy(e => e.DistanceTravelled - oldDistance[e]) as ProductionRemoteControlCar)?.RegisterVictory();
        }


        public static List<ProductionRemoteControlCar> GetRankedCars(params IRemoteControlCar[] source)
        {
            return GetRankedCars(source.ToList());
        }
        public static List<ProductionRemoteControlCar> GetRankedCars(IEnumerable<IRemoteControlCar> sourceList)
        {
            var resultList =
                sourceList.Where(e => e is ProductionRemoteControlCar).Select(e => (ProductionRemoteControlCar)e).ToList();
            resultList.Sort();
            return resultList;
        }
    }
}
