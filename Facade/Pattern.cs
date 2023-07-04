using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    //1st part of the difficult system
    public class SubsystemA
    {
        public void Functionality()
        {
            Console.WriteLine("Difficult functionality of subsystem A is working!");
        }
    }

    //2nd part of the difficult system
    public class SubsystemB
    {
        public void Functionality()
        {
            Console.WriteLine("Difficult functionality of subsystem B is working!");
        }
    }

    //3rd part of the difficult system
    public class SubsystemC
    {
        public void Functionality()
        {
            Console.WriteLine("Difficult functionality of subsystem C is working!");
        }
    }

    //class-Facade, that make access to the difficult functionality easier for client
    public class Facade
    {
        private SubsystemA subsystemA;
        private SubsystemB subsystemB;
        private SubsystemC subsystemC;

        public Facade(SubsystemA a, SubsystemB b, SubsystemC c)
        {
            subsystemA = a;
            subsystemB = b;
            subsystemC = c;
        }

        public void FirstOperation()
        {
            subsystemA.Functionality();
            subsystemB.Functionality();
            subsystemC.Functionality();
        }

        public void SecondOperation()
        {
            subsystemC.Functionality();
            subsystemA.Functionality();
        }
    }
}
