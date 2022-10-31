/*
 1.
Создайте программу C#, которая реализует интерфейс IVehicle с двумя методами:
один для Drive типа void, который имеет параметр типа integer с расстоянием поездки и другой для Refuel типа bool,
который имеет параметр типа integer с количеством бензина для заправки.
Затем создайте абстрактный класс Car с конструктором,
который получает параметр с начальным количеством топлива для автомобиля и его расход
и реализует методы Drive и Refuel автомобиля.

Создайте 2 класса SportsCar, Truck, которые будут наследоваться от Car

Метод Drive выведет на экран сообщение о том, что автомобиль движется,
если уровень бензина больше 0.
Метод Refuel увеличит количество бензина в автомобиле и вернет значение true.

Для проведения тестов создайте объект типа Автомобиль с 0 бензина в Главной части программы
и запросите у пользователя количество бензина для заправки, в завершение выполните метод Drive автомобиля.
 */
/*
2.
Был разработан экспериментальный автомобиль, и тестовый трек необходимо адаптировать для работы как с серийными,
так и с экспериментальными моделями.
Два типа автомобилей уже построены, и вам нужно найти способ справиться с ними обоими на тестовой трассе.

Кроме того, серийные автомобили начинают пользоваться определенным успехом.
Босс команды стремится поддерживать соревновательный дух,
публикуя рейтинг серийных автомобилей.

2.1 Добавьте метод в интерфейс IRemoteControlCar для предоставления реализации Drive() для двух типов автомобилей.

TestTrack.Race(new ProductionRemoteControlCar());
TestTrack.Race(new ExperimentalRemoteControlCar());
// this should execute without an exception being thrown

2.2 Включите возможность сравнения расстояния, пройденного разными моделями на тестовом треке.
Добавьте свойство в интерфейс IRemoteControlCar, чтобы предоставить реализации свойства DistanceTravelled для двух типов автомобилей.

var prod = new ProductionRemoteControlCar();
TestTrack.Race(prod);
var exp = new ExperimentalRemoteControlCar();
TestTrack.Race(exp);
prod.DistanceTravelled
// => 10
exp.DistanceTravelled
// => 20

2.3 Сделать рейтинг серийных автомобилей
Реализуйте интерфейс IComparable<T> в классе ProductionRemoteControlCar. Порядок сортировки автомобилей по умолчанию должен быть в порядке возрастания количества побед.

Реализуйте статический TestTrack.GetRankedCars(), чтобы вернуть пройденные автомобили, отсортированные в порядке возрастания количества побед.

var prc1 = new ProductionRemoteControlCar();
var prc2 = new ProductionRemoteControlCar();
prc1.NumberOfVictories = 3;
prc2.NumberOfVictories = 2;
var rankings = TestTrack.GetRankedCars(prc1, prc2);
// => rankings[1] == prc1
*/
using ConsoleApp1.FirstTask;
using ConsoleApp1.SecondTask;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1
            var car = new SportsCar(0, 8);
            car.Drive(1);
            do
            {
                try
                {
                    Console.WriteLine("Enter amount of fuel to refuel");
                    car.Refuel(Convert.ToInt32(Console.ReadLine()));
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter a number");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Enter positive amount");
                };
            } while (true);
            car.Drive(3);


            Console.WriteLine("Enter any key to continue");
            Console.ReadKey();
            
            
            //2
            var e1 = new ExperementalRemoteControlCar(15, 5);
            var e2 = new ExperementalRemoteControlCar(15, 7);
            var p1 = new ProductionRemoteControlCar(15, 6);
            var p2 = new ProductionRemoteControlCar(15, 4);

            TestTruck.Race(e1, e2, p1, p2);

            int startFuel = 50, raceAmount = 20;

            ProductionRemoteControlCar[] pcars = new ProductionRemoteControlCar[5];
            for (int i = 0; i < pcars.Length; i++)
            {
                pcars[i] = new ProductionRemoteControlCar(startFuel, 4 + Random.Shared.Next() % 11);
            }
            for (int i = 0; i < raceAmount; i++)
            {
                TestTruck.Race(pcars);
                foreach (var p in pcars)
                {
                    p.Refuel(10 + Random.Shared.Next() % 70);
                }
            }
            var rankedList = TestTruck.GetRankedCars(pcars);


            Console.WriteLine("First Race:");
            Console.WriteLine(e1);
            Console.WriteLine(e2);
            Console.WriteLine(p1);
            Console.WriteLine(p2);

            Console.WriteLine($"Top of {raceAmount} races");
            rankedList.ForEach(Console.WriteLine);
        }
    }

}