using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    //We can use this pattern when we need to change functionality
    //of many objects, but we won't change their inner structure
    

    //We abstraction for classes that can visit objects and change their functionality
    public interface IVisitor 
    {
        public void VisitElementA(ElementA elementA);
        public void VisitElementB(ElementB elementB);
    }

    //Realisation of Visitor - 1
    public class FirstVisitor : IVisitor
    {
        public void VisitElementA(ElementA elementA)
        {
            elementA.ForVisitor();
        }

        public void VisitElementB(ElementB elementB)
        {
            elementB.ForVisitor();
        }
    }

    //Realisation of Visitor - 2
    public class SecondVisitor : IVisitor
    {
        public void VisitElementA(ElementA elementA)
        {
            elementA.ForVisitor();
        }

        public void VisitElementB(ElementB elementB)
        {
            elementB.ForVisitor();
        }
    }

    //The abstraction of the class, that's functionality we can change or call with Visitor
    public abstract class Element
    {
        public abstract void Accept(IVisitor visitor);

        public void ForVisitor()
        {

        }
    }

    //Realisation A
    public class ElementA : Element
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitElementA(this);
        }
    }

    //Realisation B
    public class ElementB : Element
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitElementB(this);
        }
    }

    //Contain all objects and give them posibility to connect with visitor 
    public class ObjectStructure
    {
        public List<Element> Elements { get; set; }

        public ObjectStructure()
        {
            Elements = new List<Element>();
        }

        public void Add(Element element)
        {
            Elements.Add(element);
        }

        public void Remove(Element element)
        {
            Elements.Remove(element);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (Element element in Elements)
            {
                element.Accept(visitor);
            }
        }
    }
}
