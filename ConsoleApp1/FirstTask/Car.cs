namespace ConsoleApp1.FirstTask
{
    public abstract class Car : IVehicle
    {
        public static int CurrentIndex = 0;

        public int Index { get; }
        public int Fuel { get; protected set; }
        public int Consumption { get; protected set; }
        public Car(int fuel, int consumption)
        {
            if (fuel < 0) throw new ArgumentException($"Fuel ({fuel}) must be positive");
            Fuel = fuel;
            Consumption = consumption;
            Index = CurrentIndex++;   
        }

        public virtual void Drive(int length)
        {
            if (Fuel >= Consumption * length)
            {
                Console.WriteLine("I'm driving");
                Fuel -= Consumption * length;
            }
            else
            {
                Console.WriteLine("Not enouth fuel");
            }
        }

        public bool Refuel(int amount)
        {
            if (amount < 0) throw new ArgumentException($"Amount ({amount}) must be positive");
            Fuel += amount;
            return true;
        }

        public override string? ToString()
        {
            return $"{GetType().Name}<{Index}>(Consuption: {Consumption})";
        }
    }

}