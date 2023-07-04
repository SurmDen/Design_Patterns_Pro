using System;
using System.Threading;
using System.Threading.Tasks;

namespace Singleton
{
    //there i would like to realize more practical version of the pattern

    //the instance of this class should be the only
    public class OS
    {
        private static OS instance;

        private static object locker = new object();

        public string Name { get; private set; }

        private OS(string name)
        {
            Name = name;
        }

        public static OS GetInstance(string name)
        {
            if (instance == null)
            {
                lock (locker)
                {
                    instance = new OS(name);
                }
            }

            return instance;
        }
    }

    //this class should use singleton class OS
    public class Computer
    {
        public OS OS { get; set; }

        public string Name { get;private set; }

        public Computer(string name)
        {
            Name = name;
        }

        public void LoadOS(string OsName)
        {
            OS = OS.GetInstance(OsName);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            //trying classical Pattern

            Singleton singleton = Singleton.GetInstance();

            Console.WriteLine("First situation: " + singleton.GetHashCode());

            Singleton singleton2 = Singleton.GetInstance();

            Console.WriteLine("First situation: "+ singleton2.GetHashCode());

            Console.WriteLine();

            //trying classical Pattern with lock-construction

            LockedSingleton lockedSingleton = LockedSingleton.GetInstance();

            Console.WriteLine("Second situation: " + lockedSingleton.GetHashCode());

            Task.Run(() => 
            {
                LockedSingleton lockedSingleton2 = LockedSingleton.GetInstance();
                Console.WriteLine("Second situation: " + lockedSingleton2.GetHashCode());
            });

            Console.WriteLine();

            //practical applying of the pattern

            Computer computer = new Computer("ASUS");

            computer.LoadOS("Windows");

            Console.WriteLine(computer.Name + ": " + computer.OS.Name);

            Computer computer2;

            Thread thread = new Thread(() => 
            { 
                computer2 = new Computer("DeLL"); 

                computer2.LoadOS("Linux");

                Console.WriteLine(computer2.Name + ": " + computer2.OS.Name);
            });

            thread.Start();

            Console.ReadLine();
        }
    }
}
