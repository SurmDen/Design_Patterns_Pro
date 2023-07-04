using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Product
    {
        private List<object> parts = new List<object>();
        
        public void AddPart(string part)
        {
            parts.Add(part);
        }
    }

    public interface IProductBuilder
    {
        public void AddPartA(string partName);
        public void AddPartB(string partName);
        public void AddPartC(string partName);

        public Product GetProduct();
    }

    public class ProductBuilder : IProductBuilder
    {
        private Product Product;

        public void AddPartA(string name)
        {
            Console.WriteLine($"Part {name} created");
        }

        public void AddPartB(string name)
        {
            Console.WriteLine($"Part {name} created");
        }

        public void AddPartC(string name)
        {
            Console.WriteLine($"Part {name} created");
        }

        public Product GetProduct()
        {
            return Product;
        }

        
    }

    public class Director
    {
        private IProductBuilder Builder;

        public Director(IProductBuilder productBuilder)
        {
            Builder = productBuilder;
        }

        public void ConstructProduct()
        {
            Builder.AddPartA("First detail");
            Builder.AddPartB("Second detail");
            Builder.AddPartC("Third detail");
        }
    }
}
