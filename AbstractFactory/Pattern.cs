using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public interface IProductA
    {

    }

    public interface IProductB
    {

    }

    public class ProductA1 : IProductA
    {

    }

    public class ProductA2 : IProductA
    {

    }

    public class ProductB1 : IProductB
    {

    }

    public class ProductB2 : IProductB
    {

    }

    public abstract class IAbstractFactory
    {
        public abstract IProductA CreateProductA();
        public abstract IProductB CreateProductB();
    }

    public class SpecificFactory1 : IAbstractFactory
    {
        public override IProductA CreateProductA()
        {
            return new ProductA1();
        }

        public override IProductB CreateProductB()
        {
            return new ProductB1();
        }
    }

    public class SpecificFactory2 : IAbstractFactory
    {
        public override IProductA CreateProductA()
        {
            return new ProductA2();
        }

        public override IProductB CreateProductB()
        {
            return new ProductB2();
        }
    }

    public class Client
    {
        private IProductA productA;
        private IProductB productB;

        public Client(IAbstractFactory abstractFactory)
        {
            productA = abstractFactory.CreateProductA();
            productB = abstractFactory.CreateProductB();
        }

        public override string ToString()
        {
            return $@"IProductA realized by {productA.GetType().Name} {Environment.NewLine}IProductB realized by {productB.GetType().Name}";
        }
    }
}
