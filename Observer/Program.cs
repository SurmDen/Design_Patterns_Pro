using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public interface IObserver
    {
        void Update(StockInfo info);
    }

    public interface IObservable
    {
        void AddSub(IObserver observer);
        void RemoveSub(IObserver observer);
        void NotifySubs();
    }

    public class StockInfo
    {
        public double USD { get; set; }
        public double EUR { get; set; }
    }

    public class InvestStock : IObservable
    {
        List<IObserver> observers;
        StockInfo info;

        public InvestStock(StockInfo stockInfo)
        {
            info = stockInfo;
            observers = new List<IObserver>();
        }

        public void AddSub(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveSub(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifySubs()
        {
            foreach (IObserver o in observers)
            {
                o.Update(info);
            }
        }
    }

    public class Brocker : IObserver
    {
        public string Name { get; set; }

        StockInfo infoForBrocker;

        IObservable observable;

        public Brocker(string name, IObservable observable)
        {
            infoForBrocker = new StockInfo();

            Name = name;

            this.observable = observable;

            observable.AddSub(this);
        }

        public void Update(StockInfo info)
        {
            if (infoForBrocker.USD == 0 && infoForBrocker.EUR == 0)
            {
                Console.WriteLine($"****for '{this.Name}'****");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"the USD start with position {info.USD}");
                Console.WriteLine($"the EUR start with position {info.EUR}");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                if (info.USD > infoForBrocker.USD && info.EUR > infoForBrocker.EUR)
                {
                    Console.WriteLine($"****for '{this.Name}'****");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"the USD up to {info.USD}");
                    Console.WriteLine($"the EUR up to {info.EUR}");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (info.USD < infoForBrocker.USD && info.EUR < infoForBrocker.EUR)
                {
                    Console.WriteLine($"****for '{this.Name}'****");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"the USD down to {info.USD}");
                    Console.WriteLine($"the EUR down to {info.EUR}");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (info.USD < infoForBrocker.USD && info.EUR > infoForBrocker.EUR)
                {
                    Console.WriteLine($"****for '{this.Name}'****");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"the USD down to {info.USD}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"the EUR up to {info.EUR}");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (info.USD > infoForBrocker.USD && info.EUR < infoForBrocker.EUR)
                {
                    Console.WriteLine($"****for '{this.Name}'****");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"the USD up to {info.USD}");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"the EUR down to {info.EUR}");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            
            infoForBrocker.USD = info.USD;
            infoForBrocker.EUR = info.EUR;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //IObservable observable = new Account();

            //for (int i = 0; i < 20; i++)
            //{
            //    observable.AddSubscriber(new Subscriber());
            //}

            //observable.NotifySubs();
            
            StockInfo stockInfo = new StockInfo()
            {
                USD = 60,
                EUR = 65
            };

            IObservable stock = new InvestStock(stockInfo);

            IObserver brocker1 = new Brocker("Denis Surmanidze", stock);
            IObserver brocker2 = new Brocker("Vlad Gordeev", stock);

            Random random = new Random();

            for (int i = 0; i < 20; i++)
            {
                stockInfo.EUR += random.Next(-5,5);
                stockInfo.USD += random.Next(-5, 5);
                stock.NotifySubs();
                System.Threading.Thread.Sleep(500);
            }

            Console.ReadLine();
        }
    }
}
