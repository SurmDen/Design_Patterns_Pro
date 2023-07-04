using System;

namespace Iterator
{
    //we use Iterator when we need enumerate the group of objects (lists, arrays, etc.)

    //The type, that we need to enumerate
    public class Car
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public Car(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }

    //interface - Enumerator for 'Car'
    public interface IPreview
    {
        public Car Current();
        public Car First();
        public Car Next();
        public bool IsTheLast();
    }

    //interface - Enumerable, contains list of 'Car'
    public interface ICarShop
    {
        public IPreview CreatePreview();
        public int Count { get; }
        public Car this[int indexer] { get; set; }
    }

    //Enumerable, contains list of 'Car'
    public class CarShop : ICarShop
    {
        public Car[] Cars = new Car[100];

        public IPreview CreatePreview()
        {
            return new CarPreview(this);
        }

        public int Count
        {
            get => Cars.Length;
        }

        public Car this[int index] 
        {
            get => Cars[index];
            set { Cars[index] = value; }
        }
    }


    //Enumerator for 'Car'
    public class CarPreview : IPreview
    {
        private readonly ICarShop carShop;
        private int current;

        public CarPreview(ICarShop carShop)
        {
            this.carShop = carShop;
        }

        public Car Current()
        {
            return carShop[current];
        }

        public Car Next()
        {
            Car car = null;

            current++;

            if (current < carShop.Count)
            {
                car = carShop[current];
            }

            return car;
        }

        public Car First()
        {
            return carShop[0];
        }

        public bool IsTheLast()
        {
            if (current >= carShop.Count)
            {
                return true;
            }

            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Aggregate aggregate = new SpecificAggregate();

            for (int i = 0; i < 100; i++)
            {
                aggregate[i] = i;
            }

            Iterator iterator = aggregate.CreateIteragor();

            while (iterator.IsDone() == false)
            {
                Console.WriteLine(iterator.Current());
                iterator.Next();
            }

            //let's I show you my version of Iterator

            ICarShop carShop = new CarShop();

            Random random = new Random();

            for (int i = 0; i < 50; i++)
            {
                carShop[i] = new Car($"Car-{i}", random.Next(10000, 50000));
            }

            IPreview preview = carShop.CreatePreview();

            while (preview.IsTheLast() == false)
            {
                try
                {
                    Console.WriteLine($"{preview.Current().Name}.....{preview.Current().Price}$");
                }
                catch
                {
                    Console.WriteLine("it,s all");
                }
                preview.Next();
            }

            //IEnumerable + IEnumerator using...

            University university = new University();

            for (int i = 0; i < 20; i++)
            {
                university.AddStudent(new Student {Name = $"Student-{i}", Age = random.Next(17,25) });
            }

            int n = 1;

            foreach (Student student in university)
            {
                Console.WriteLine($"{n}) {student.Name},  {student.Age},  {student.Country}");
                n++;
            }

            Console.ReadLine();
        }
    }
}
