using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    //The class-saver; We create new instanse for each Originator State
    public class Memento
    {
        public Memento(string state)
        {
            State = state;
        }

        public string State { get;private set; }
    }

    //The class That we have to save (even more the one time)
    public class Originator
    {
        public string State { get; set; }

        public Memento SetState()
        {
            return new Memento(State);
        }

        public void GetMemento(Memento memento)
        {
            State = memento.State;
        }
    }

    //the class-repository fow mementoes!!!
    public class CareTaker
    {

    }
}
