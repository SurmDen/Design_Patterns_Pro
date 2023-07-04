using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Observer
//{
//    //the abstraction of class - subscriber
//    public interface IObserver 
//    {
//        void Update();
//    }

//    //class - subscriber
//    public class Subscriber : IObserver
//    {
//        static int counter = 0;

//        public int Id { get; set; }

//        public void Update()
//        {
//            counter++;
//            Id = counter;
//            Console.WriteLine($"The subscriber #_{Id} is updated!");
//        }
//    }

//    //the abstraction of the class we need subscribe on (contain all subscribers)
//    public interface IObservable
//    {
//        void AddSubscriber(IObserver observer);
//        void RemoveSubscriber(IObserver observer);
//        void NotifySubs();
//    }


//    //class we need subscribe on (contain all subscribers)
//    public class Account : IObservable
//    {
//        List<IObserver> subscribers;

//        public Account(List<IObserver> subscribers)
//        {
//            this.subscribers = subscribers;
//        }

//        public Account()
//        {
//            subscribers = new List<IObserver>();
//        }

//        public void AddSubscriber(IObserver observer)
//        {
//            subscribers.Add(observer);
//        }

//        public void NotifySubs()
//        {
//            foreach (IObserver o in subscribers)
//            {
//                o.Update();
//            }
//        }

//        public void RemoveSubscriber(IObserver observer)
//        {
//            subscribers.Remove(observer);
//        }
//    }
//}
