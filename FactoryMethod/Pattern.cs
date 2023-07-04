using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    //abstract class, that's inherited class's instances we should create
    public interface IProduct
    {
        public string Name { get;set; }
    }

    //abstract class, that's inherited class's instances can create specific instances of 'Product'
    public interface ICreator
    {
        public IProduct FactoryMethod();
    }

    //specific product A
    public class ProductA : IProduct
    {
        public string Name { get;set; }

        public ProductA()
        {

        }
    }

    //specific product B
    public class ProductB : IProduct
    {
        public string Name { get; set; }

        public ProductB()
        {

        }
    }

    //specific creator for product A
    public class CreatorA : ICreator
    {
        public IProduct FactoryMethod()
        {
            return new ProductA();
        }
    }

    //specific creator for product B
    public class CreatorB : ICreator
    {
        public IProduct FactoryMethod()
        {
            return new ProductB();
        }
    }
}
