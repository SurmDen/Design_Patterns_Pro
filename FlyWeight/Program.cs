using System;
using System.Collections;
using System.Collections.Generic;

namespace FlyWeight
{
    public class HouseParameters
    {
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public string Color { get; set; }

        public HouseParameters(int lat, int lon, string Color)
        {
            Latitude = lat;
            Longitude = lon;
            this.Color = Color;
        }
    }
    //Flyweight class, that gives posibility to inherited
    //classes devide state on inner and extern
    //in the result, one object can be used many times in different contexts
    public abstract class House
    {
        protected int stages;

        public abstract void CreateHouse(HouseParameters parameters);
    }

    public class PannelHouse : House
    {
        public PannelHouse()
        {
            stages = 10;
        }

        public override void CreateHouse(HouseParameters parameters)
        {
            Console.WriteLine($"Pannel House ({stages} stages) [lat: {parameters.Latitude}, " +
                $"lon: {parameters.Longitude}] with color: {parameters.Color} have just started to create!");
        }
    }

    public class BrickHouse : House
    {
        public BrickHouse()
        {
            stages = 5;
        }

        public override void CreateHouse(HouseParameters parameters)
        {
            Console.WriteLine($"Brick House ({stages} stages) [lat: {parameters.Latitude}, " +
                $"lon: {parameters.Longitude}] with color: {parameters.Color} have just started to create!");
        }
    }

    //Flyweight factory (responsible for giving House objects)
    public class HouseFactory
    {
        Dictionary<string, House> houses = new Dictionary<string, House>();

        public HouseFactory()
        {
            houses.Add("Pannel", new PannelHouse());
            houses.Add("Brick", new BrickHouse()); ;
        }

        public House GetHouse(string name)
        {
            return houses[name];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            HouseFactory factory = new HouseFactory();
            PannelHouse house = factory.GetHouse("Pannel") as PannelHouse;
            house.CreateHouse(new HouseParameters(44, 56, "Red")) ;
            Console.WriteLine();

            BrickHouse brickHouse = factory.GetHouse("Brick") as BrickHouse;
            brickHouse.CreateHouse(new HouseParameters(76, 46, "Green"));
            Console.WriteLine(brickHouse.GetHashCode());
            Console.WriteLine();

            BrickHouse brickHouse2 = factory.GetHouse("Brick") as BrickHouse;
            brickHouse.CreateHouse(new HouseParameters(32, 27, "Yellow"));
            Console.WriteLine(brickHouse.GetHashCode());

            Console.ReadLine();
        }
    }
}
