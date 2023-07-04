using System;

namespace Chain_Of_Responsibility
{
    //we use this pattern in next cases:

        //1) When client don't know anything about executers and how his request is executed
        //2) There are lot's of instances, and one of them can handle request (depends from conditions)
        //3) we can create handlers dynamically


    //conditions
    public enum Difficulty
    {
        Easy = 1,
        Normal = 2,
        Hard = 3
    }

    //handler
    public abstract class Executer
    {
        public Executer NextExecuter { get; set; }

        public abstract void Execute(Difficulty difficulty);
    }

    //specific handler 1
    public class Cadet : Executer
    {
        public override void Execute(Difficulty difficulty)
        {
            if (difficulty == (Difficulty)1)
            {
                Console.WriteLine("Cadet executed task!");
            }
            else if (NextExecuter != null)
            {
                NextExecuter.Execute(difficulty);
            }
        }
    }

    //specific handler 2
    public class Officer : Executer
    {
        public override void Execute(Difficulty difficulty)
        {
            if (difficulty == Difficulty.Normal)
            {
                Console.WriteLine("Officer executed task!");
            }
            else if (NextExecuter != null)
            {
                NextExecuter.Execute(difficulty);
            }
        }
    }

    //specific handler 3
    public class General: Executer
    {
        public override void Execute(Difficulty difficulty)
        {
            if (difficulty == Difficulty.Hard)
            {
                Console.WriteLine("General-oral executed task!");
            }
            else if (NextExecuter != null)
            {
                NextExecuter.Execute(difficulty);
            }
            else
            {
                Console.WriteLine("No one can execute this task!!!");
            }
        }
    }

    //client
    class Academy
    {
        static void Main(string[] args)
        {
            Handler handler1 = new SpecificHandler_1();
            Handler handler2 = new SpecificHandler_2();

            handler1.OtherHandler = handler2;

            handler1.HandleRequest(1);

            /////////////////////////////////

            Executer cadet = new Cadet();
            Executer officer = new Officer();
            Executer general = new General();

            cadet.NextExecuter = officer;
            officer.NextExecuter = general;

            cadet.Execute(Difficulty.Hard);

            Console.ReadLine();
        }
    }
}
