using System;


namespace Decorator
{
    //we also use Decorator pattern when we need dynamicly change
    //object without ctreating a new object

    //the abstraction for classes that's objects we need to create
    public abstract class Pizza
    {
        public string Name { get; set; }

        public Pizza(string name)
        {
            this.Name = name;
        }

        public abstract int GetCost();
    }

    //specific realization of 'Pizza' - 1
    public class ItalianPizza : Pizza
    {
        public ItalianPizza() : base("Italian pizza")
        {

        }

        public override int GetCost()
        {
            return 10;
        }
    }

    //specific realization of 'Pizza' - 2
    public class BulgarianPizza : Pizza
    {
        public BulgarianPizza() : base("Bulgarian pizza")
        {

        }

        public override int GetCost()
        {
            return 8;
        }
    }

    //the abstraction for class - DECORATOR for 'Pizza'
    public abstract class PizzaDecorator : Pizza
    {
        protected Pizza Pizza;

        public PizzaDecorator(string name, Pizza pizza) : base(name)
        {
            Pizza = pizza;
        }
    }

    //specific Decorator - 1
    public class PizzaWithTomatoes: PizzaDecorator
    {
        public PizzaWithTomatoes(Pizza pizza) : base($"{pizza.Name}, with tomatoes", pizza)
        {

        }

        public override int GetCost()
        {
            return Pizza.GetCost() + 2;
        }
    }

    //specific Decorator - 1
    public class PizzaWithCheese : PizzaDecorator
    {
        public PizzaWithCheese(Pizza pizza) : base($"{pizza.Name}, with cheese", pizza)
        {

        }

        public override int GetCost()
        {
            return Pizza.GetCost() + 3;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza = new ItalianPizza();
            pizza = new PizzaWithCheese(pizza);
            Console.WriteLine($"{pizza.Name}, cost: {pizza.GetCost()}");
            pizza = new PizzaWithTomatoes(pizza);
            Console.WriteLine($"{pizza.Name}, cost: {pizza.GetCost()}");

            Console.ReadLine();
        }
    }
}
