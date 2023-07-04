using System;

namespace Adapter
{
    public interface ITransport
    {
        public void Drive();
    }

    public class Car : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("The car is driving on roads");
        }
    }

    public interface IAnimal
    {
        public void Move();
    }

    public class Camel : IAnimal
    {
        public void Move()
        {
            Console.WriteLine("Camel is moving by deserts");
        }
    }

    public class CarToCamelAdapter : ITransport
    {
        private IAnimal Animal;

        public CarToCamelAdapter(IAnimal animal)
        {
            Animal = animal;
        }

        public void Drive()
        {
            Animal.Move();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ITransport transport = new Car();
            transport.Drive();

            transport = new CarToCamelAdapter(new Camel());
            transport.Drive();

            Console.ReadLine();
        }
    }
}
