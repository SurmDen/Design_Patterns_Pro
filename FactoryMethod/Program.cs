using System;

namespace FactoryMethod
{
    public interface IVehicle
    {

    }

    public class Unicycle : IVehicle
    {
        public Unicycle()
        {
            Console.WriteLine("You choose a Unicycle!");
        }
    }

    public class Motobike : IVehicle
    {
        public Motobike()
        {
            Console.WriteLine("You choose a Motobike!");
        }
    }

    public class Car : IVehicle
    {
        public Car()
        {
            Console.WriteLine("You choose a Car!");
        }
    }

    public class Track : IVehicle
    {
        public Track()
        {
            Console.WriteLine("You choose a Lorry!");
        }
    }

    public class Hybrid: IVehicle
    {
        public Hybrid()
        {
            Console.WriteLine("You choose something unimaginable!");
        }
    }

    public interface IVehicleManager
    {
        public IVehicle GetVehicle(int wheelsCount);
    }

    public class VehicleManager : IVehicleManager
    {
        public IVehicle GetVehicle(int wheelsCount)
        {
            switch (wheelsCount)
            {
                case 1: return new Unicycle();
                    
                case 2: return new Motobike();
                    
                case 3: return new Motobike();

                case 4:return new Car();
                    
                case 5: return new Track();

                default:return new Hybrid();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Testing of standart Factory Method
            ICreator creator;

            IProduct product;

            //we need to create a Product A instance

            creator = new CreatorA();

            product = creator.FactoryMethod();

            product.Name = "cock increaser for Azizai";

            Console.WriteLine(DateTime.Now + " " + product.Name);

            //then we saddenly solute to create a Product B instance, OMG, what should I Do!!!!
            //don't worry babe, there is a decision))

            creator = new CreatorB();

            product = creator.FactoryMethod();

            product.Name = "pink thongs for men";

            Console.WriteLine();

            Console.WriteLine(DateTime.Now + " " + product.Name);

            //let's test our version of the pattern
            Console.Write(Environment.NewLine);

            IVehicleManager manager = new VehicleManager();

            IVehicle vehicle;

            while (true)
            {
                Console.WriteLine("Input number of wheels for choosing a vehicle: ");

                int n = int.Parse(Console.ReadLine());

                vehicle = manager.GetVehicle(n);

                Console.WriteLine("Is it your final choise!? Tap 'y' - yes, 'n' - no");

                Console.Write("Insert: ");

                string answer = Console.ReadLine();

                if (answer.ToLower().StartsWith("y"))
                {
                    break;
                }
                else
                {
                    continue;
                }
            }

            Console.WriteLine($"The final choise is: {vehicle.GetType().Name}");

            Console.ReadKey();
        }
    }
}
