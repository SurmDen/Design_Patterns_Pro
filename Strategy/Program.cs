using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public interface ISortable
    {
        void Sort();
    }

    public class BubbleSort : ISortable
    {
        public void Sort()
        {
            Console.WriteLine("Bubble sort algoritm");
        }
    }

    public class ElectSort : ISortable
    {
        public void Sort()
        {
            Console.WriteLine("Elect sort algoritm");
        }
    }

    public class MergeSort : ISortable
    {
        public void Sort()
        {
            Console.WriteLine("Merge sort algoritm");
        }
    }

    public class AlgoritmContext
    {
        public ISortable SortAlgoritm { get; set; }

        public AlgoritmContext(ISortable sortable)
        {
            SortAlgoritm = sortable;
        }

        public void GetAlgoritm(params object[] values)
        {
            SortAlgoritm.Sort();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IStrategy strategy = new StrategyA();

            Context context = new Context(strategy);

            context.ExecuteAlgoritm();

            strategy = new StrategyB();

            context = new Context(strategy);

            context.ExecuteAlgoritm();

            //let's try my personal realization of algoritm

            ISortable sortable = new MergeSort();

            AlgoritmContext algoritm = new AlgoritmContext(sortable);

            List<int> values = new List<int>();

            algoritm.GetAlgoritm(values);

            Console.ReadLine();
        }
    }
}
