using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    //abstraction for state classes
    public interface IState
    {
        public void Handle(Context context);
    }

    //certain state-1 of instanse
    public class StateA : IState
    {
        public void Handle(Context context)
        {
            context.State = new StateB();
        }
    }

    //certain state-2 of instanse
    public class StateB : IState
    {
        public void Handle(Context context)
        {
            context.State = new StateA();
        }
    }

    //class with changing states
    public class Context
    {
        public IState State { get; set; }

        public Context(IState state)
        {
            State = state;
        }

        public void ChangeState()
        {
            State.Handle(this);
        }
    }
}
