using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    //we use Prototype when we mostly need to create
    //copy of class's instance instead of new instance
    //***EXAMPLE***

    public interface IFigure
    {
        public IFigure Clone();
        public void GetInfo();
        public void AddStartPoint(int x, int y);
    }

    //we make it class to show that using MemberWiseClone() we can't copy ref type; we'll have the same refs!!!
    public class StartPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public StartPoint(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public StartPoint Clone()
        {
            return this.MemberwiseClone() as StartPoint;
        }
    }

    //Specific IFigure interface realization
    public class Rectangle : IFigure
    {
        public StartPoint StartPoint { get; set; } = new StartPoint();

        public int Length { get; set; }

        public int Width { get; set; }

        public Rectangle(int a, int b)
        {
            Length = a;
            Width = b;
        }

        public Rectangle()
        {

        }

        public IFigure Clone()
        {
            return this.MemberwiseClone() as Rectangle;
        }

        public void GetInfo()
        {
            Console.WriteLine($"The {this.GetType().Name} has H: " +
                $"{this.Length}, W: {this.Width} and start in ({this.StartPoint.X}, {this.StartPoint.Y})");
        }

        public void AddStartPoint(int a, int b)
        {
            StartPoint.X = a;
            StartPoint.Y = b;
        }

        public static explicit operator Rectangle(Sircle sircle)
        {
            return new Rectangle {Length = sircle.Radius, Width = sircle.Radius, StartPoint = sircle.StartPoint.Clone()};
        }

        public static explicit operator Sircle(Rectangle r)
        {
            return new Sircle() {Radius = (int)System.Math.Sqrt(r.Width*r.Length/3.14),StartPoint = r.StartPoint.Clone() };
        }
    }

    //Specific IFigure interface realization
    public class Sircle : IFigure
    {
        public StartPoint StartPoint { get; set; } = new StartPoint();

        public int Radius { get; set; }

        public Sircle(int r = 0)
        {
            Radius = r;
        }

        public Sircle()
        {

        }

        public IFigure Clone()
        {
            return this.MemberwiseClone() as Sircle;
        }

        public void GetInfo()
        {
            Console.WriteLine($"The {this.GetType().Name} has R: " +
                $"{this.Radius} and start in ({this.StartPoint.X}, {this.StartPoint.Y})");
        }

        public void AddStartPoint(int a, int b)
        {
            StartPoint.X = a;
            StartPoint.Y = b;
        }

        
    }

    class Program
    {
        static void Main(string[] args)
        {
            IFigure rect1 = new Rectangle(10, 5);

            rect1.AddStartPoint(2, 2);

            rect1.GetInfo();

            IFigure rect2 = rect1.Clone();

            rect2.GetInfo();

            //then we change startpoint in one of then
            Console.WriteLine();

            rect2.AddStartPoint(5,5);

            rect1.GetInfo();

            rect2.GetInfo();

            //that's are substractions of using MemberWiseClone()!

            Rectangle rectangle = rect2.Clone() as Rectangle;

            Sircle sircle = (Sircle)rectangle;

            Console.WriteLine();

            sircle.GetInfo();

            Console.ReadLine();
        }
    }
}
