using System;

namespace AbstractFactory
{
    //abstract classes for Hero parameters
    public interface IWeapon
    {
        public void AddWeapon();
    }

    public interface IMovement
    {
        public void AddMovingAbilities();
    }

    //specific realize
    public class Sword : IWeapon
    {
        public void AddWeapon()
        {
            Console.WriteLine("The sword is added to Hero!");
        }
    }

    public class CrossBow : IWeapon
    {
        public void AddWeapon()
        {
            Console.WriteLine("The crossbow is added to Hero!");
        }
    }

    public class Run: IMovement
    {
        public void AddMovingAbilities()
        {
            Console.WriteLine("The hero can running");
        }
    }

    public class Flight : IMovement
    {
        public void AddMovingAbilities()
        {
            Console.WriteLine("The hero can flying!");
        }
    }


    public interface IHeroFactory
    {
        public IMovement AddMovement();
        public IWeapon AddWeapon();
    }

    public class DragonLord : IHeroFactory
    {
        public IMovement AddMovement()
        {
            return new Flight();
        }

        public IWeapon AddWeapon()
        {
            return new Sword();
        }
    }

    public class EvaElfie : IHeroFactory
    {
        public IMovement AddMovement()
        {
            return new Run();
        }

        public IWeapon AddWeapon()
        {
            return new CrossBow();
        }
    }

    public class Hero
    {
        public IMovement Movement { get; private set; }
        public IWeapon Weapon { get; private set; }

        public Hero(IHeroFactory heroFactory)
        {
            Movement = heroFactory.AddMovement();
            Weapon = heroFactory.AddWeapon();
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine($"Hero {heroFactory.GetType().Name} successfully created!");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            IAbstractFactory abstractFactory = new SpecificFactory1();

            IProductA productA = abstractFactory.CreateProductA();
            IProductB productB = abstractFactory.CreateProductB();

            Client client = new Client(abstractFactory);
            Console.WriteLine(client.ToString());

            abstractFactory = new SpecificFactory2();

            productA = abstractFactory.CreateProductA();
            productB = abstractFactory.CreateProductB();

            client = new Client(abstractFactory);
            Console.WriteLine(client.ToString());

            //we use abstract factory when the main class HAS A group of linked classes

            //let's try on my example to this patten

            IHeroFactory heroFactory = new EvaElfie();

            Hero hero = new Hero(heroFactory);

            heroFactory = new DragonLord();

            hero = new Hero(heroFactory);

            Console.ReadLine();
        }
    }
}
