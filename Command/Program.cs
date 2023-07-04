using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class Work
    {
        public void Start()
        {
            Console.WriteLine("Nigga working!!!");
        }

        public void End()
        {
            Console.WriteLine("The work is ending!");
        }
    }

    public interface ISlavable
    {
        void StartWork();
        void EndWork();
    }

    public class Nigger : ISlavable
    {
        private Work Work;

        public Nigger(Work work)
        {
            Work = work;
        }

        public void StartWork()
        {
            Work.Start();
        }

        public void EndWork()
        {
            Work.End();
        }
    }

    public class AnyWhiteMan
    {
        public AnyWhiteMan()
        {

        }

        private Nigger Nigger;

        public void GetNigger(Nigger nigger)
        {
            Nigger = nigger;
        }

        public void DoSomething()
        {
            Nigger.StartWork();
        }

        public void StopActivity()
        {
            Nigger.EndWork();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Nigger nigger = new Nigger(new Work());

            AnyWhiteMan whiteMan = new AnyWhiteMan();

            whiteMan.GetNigger(nigger);

            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                Console.ForegroundColor = (ConsoleColor)random.Next(1, 15);
                whiteMan.DoSomething();
                System.Threading.Thread.Sleep(100);
            }

            whiteMan.StopActivity();

            Console.ReadLine();
        }
    }
}
