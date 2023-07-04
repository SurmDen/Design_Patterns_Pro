using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    //the base interface for classes, that realize algoritms
    public interface IStrategy
    {
        void Algoritm();
    }

    //specific realization of algo.. A
    public class StrategyA : IStrategy
    {
        public void Algoritm()
        {
            Console.WriteLine("Execute algoritm A");
        }
    }

    //specific realization of algo.. B
    public class StrategyB : IStrategy
    {
        public void Algoritm()
        {
            Console.WriteLine("Execute algoritm B");
        }
    }

    //Class that define needed algoritm
    public class Context
    {
        public IStrategy ContextStrategy { get; set; }

        public Context(IStrategy strategy)
        {
            ContextStrategy = strategy;
        }

        public void ExecuteAlgoritm()
        {
            ContextStrategy.Algoritm();
        }
    }
}
