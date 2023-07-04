using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_Of_Responsibility
{
    public abstract class Handler
    {
        public Handler OtherHandler { get; set; }

        public abstract void HandleRequest(int condition);
    }

    public class SpecificHandler_1: Handler
    {
        public override void HandleRequest(int condition)
        {
            if (condition == 1)
            {
                Console.WriteLine($"Request handled by handler {this.GetHashCode().ToString().ToUpper()}");
            }
            else if (condition == 2)
            {
                if (OtherHandler != null)
                {
                    OtherHandler.HandleRequest(condition);
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }

    public class SpecificHandler_2 : Handler
    {
        public override void HandleRequest(int condition)
        {
            if (condition == 2)
            {
                Console.WriteLine($"Request handled by handler {this.GetHashCode().ToString().ToUpper()}");
            }
            else if (condition == 1)
            {
                if (OtherHandler != null)
                {
                    OtherHandler.HandleRequest(condition);
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
