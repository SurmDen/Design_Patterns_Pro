using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    //the class-invoker: it's only can do some actions
    public class Receiver
    {
        public void ExecuteCommand()
        {
            Console.WriteLine("Command executed");
        }

        public void UndoCommand()
        {
            Console.WriteLine("The command canceled");
        }        
    }

    //interface for commander
    public interface ICommander
    {
        void Execute();
        void Undo();
    }

    //class-commander: aggregate the class-invoker(Receiver)
    //Receive requests and give responces, calling Receiver's methods
    public class Command : ICommander
    {
        Receiver receiver;

        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public void Execute()
        {
            receiver.ExecuteCommand();
        }

        public void Undo()
        {
            receiver.UndoCommand();
        }
    }


    //Aggregate Commander and makes requests by him
    //IT'S NOTHING KNOW ABOUT RECEIVER!!!!!!!!!!!!!
    public class CommandManager
    {
        private ICommander commander;

        public CommandManager(ICommander commander)
        {
            this.commander = commander;
        }

        public CommandManager()
        {

        }

        public void GetCommander(ICommander commander)
        {
            this.commander = commander;
        }

        public void PostCommand()
        {
            commander.Execute();
        }

        public void UnpostCommand()
        {
            commander.Undo();
        }
    }
}
