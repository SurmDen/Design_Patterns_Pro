using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    //We need to make Adapter to this class
    public class Target
    {
        public virtual void Request()
        {
            Console.WriteLine("Request by target class");
        }

    }

    // We wan't to call Request of this class instead 'Adapter'
    public class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Request by Adaptee");
        }
    }


    // Class - adapter
    public class Adapter : Target
    {
        Adaptee Adaptee = new Adaptee();

        public override void Request()
        {
            Adaptee.SpecificRequest();
        }
    }

    //Client believe that he calls Adapter's methods, but really we call Adaptee's one's
    public class Client
    {
        public void MakeRequest(Target target)
        {
            target.Request();
        }

    }
}
