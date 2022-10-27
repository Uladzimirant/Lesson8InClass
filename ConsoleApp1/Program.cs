﻿/*
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

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
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
        }
    }

}