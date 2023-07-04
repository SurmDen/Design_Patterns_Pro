using System;

namespace State
{
    //We apply this pattern, when behaviour of the instanse depends from it's inner state

    public class Water
    {
        public IWaterState state;

        public Water(IWaterState state )
        {
            this.state = state;
        }

        public void IncreaseTemperature()
        {
            state.Heat(this);
        }

        public void ReduceTemperature()
        {
            state.Frost(this);
        }
    }

    public interface IWaterState
    {
        void Frost(Water water);
        void Heat(Water water);
    }

    public class Liquid : IWaterState
    {
        public void Frost(Water water)
        {
            Console.WriteLine("Water -->  Ice");
            water.state = new Ice();
        }

        public void Heat(Water water)
        {
            Console.WriteLine("Water -->  Vape");
            water.state = new Vape();
        }
    }

    public class Vape : IWaterState
    {
        public void Frost(Water water)
        {
            Console.WriteLine("Vape -->  Liquid");
            water.state = new Liquid();
        }

        public void Heat(Water water)
        {
            Console.WriteLine("Gas's energy increasing");
        }
    }

    public class Ice : IWaterState
    {
        public void Frost(Water water)
        {
            Console.WriteLine("Ice's energy reducing");
        }

        public void Heat(Water water)
        {
            Console.WriteLine("Ice -->  Liquid");
            water.state = new Liquid();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Water water = new Water(new Liquid());
            water.IncreaseTemperature();
            water.IncreaseTemperature();
            water.ReduceTemperature();
            water.ReduceTemperature();
            water.IncreaseTemperature();

            Console.ReadLine();
        }
    }
}
