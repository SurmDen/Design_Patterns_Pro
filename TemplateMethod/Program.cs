using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    //we use this pattern when we have template of the algoritm
    //in the abstract class, but we also can override it in inherited classes

    //let's see my realize of the pattern

    public abstract class Education
    {
        public string Name { get; set; }

        public Education(string name)
        {
            Name = name;
        }

        //the base algoritms structure for inherited classes
        public void ShowAducationalProcess()
        {
            EnterAducationalEstablishment();
            Study();
            GrowUp();
        }

        //methods for overriding
        public abstract void EnterAducationalEstablishment();
        public abstract void Study();
        public abstract void GrowUp();
    }

    public class School : Education
    {
        public School(string name, string country) : base(name)
        {
            Country = country;
        }

        public string Country { get; set; }

        public override void EnterAducationalEstablishment()
        {
            Console.WriteLine("I am starting my school way");
        }

        public override void Study()
        {
            Console.WriteLine("School process...");
        }

        public override void GrowUp()
        {
            Console.WriteLine("The best school years have just ended");
        }
    }

    public class University : Education
    {
        public University(string name, string country) : base(name)
        {
            Country = country;
        }

        public string Country { get; set; }

        public override void EnterAducationalEstablishment()
        {
            Console.WriteLine("I am starting my high education");
        }

        public override void Study()
        {
            Console.WriteLine("Difficult process...");
        }

        public override void GrowUp()
        {
            Console.WriteLine("The best students years have just ended");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Education education = new School("Eton", "Great Britain");

            education.ShowAducationalProcess();

            Console.Write(Environment.NewLine);

            education = new University("Harward","USA");

            education.ShowAducationalProcess();

            Console.ReadLine();
        }
    }
}
