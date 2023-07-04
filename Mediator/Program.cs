using System;
using System.Collections.Generic;

namespace Mediator
{
    public interface IMediator
    {
        public void Send(string message, Developer developer);
    }

    public class Manager : IMediator
    {

        public Programmer Programmer { get; set; }
        public Designer Designer { get; set; }
        public Tester Tester { get; set; }

        public void Send(string message, Developer developer)
        {
            if (developer == Programmer)
            {
                Designer.Notify(message, developer);
                Tester.Notify(message, developer);

            }

            if (developer == Tester)
            {
                Designer.Notify(message, developer);
                Programmer.Notify(message, developer);

            }

            if (developer == Designer)
            {
                Programmer.Notify(message, developer);
                Tester.Notify(message, developer);

            }
        }
    }

    public abstract class Developer
    {
        public string Name { get; set; }

        public IMediator Mediator { get; set; }

        public Developer(IMediator mediator)
        {
            Mediator = mediator;
        }

        public abstract void Send(string message);
        public abstract void Notify(string message, Developer developer);
    }

    public class Programmer : Developer
    {
        private static int count;

        public Programmer(IMediator mediator) : base(mediator)
        {
            count++;
            Name = $"Proggramer_{count}";
        }

        public override void Send(string message)
        {
            Mediator.Send(message, this);
        }

        public override void Notify(string message, Developer developer)
        {
            Console.WriteLine($"from {developer.Name}: {message}");
        }
    }

    public class Tester : Developer
    {
        private static int count;

        public Tester(IMediator mediator) : base(mediator)
        {
            count++;
            Name = $"Tester_{count}";
        }

        public override void Send(string message)
        {
            Mediator.Send(message, this);
        }

        public override void Notify(string message, Developer developer)
        {
            Console.WriteLine($"from {developer.Name}: {message}");
        }
    }

    public class Designer : Developer
    {
        private static int count;

        public Designer(IMediator mediator) : base(mediator)
        {
            count++;
            Name = $"Designer_{count}";
        }

        public override void Send(string message)
        {
            Mediator.Send(message, this);
        }

        public override void Notify(string message, Developer developer)
        {
            Console.WriteLine($"from {developer.Name}: {message}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Manager mediator = new Manager();

            Developer proger = new Programmer(mediator);
            Developer tester = new Tester(mediator);
            Developer designer = new Designer(mediator);

            mediator.Designer = designer as Designer;
            mediator.Programmer = proger as Programmer;
            mediator.Tester = tester as Tester;

            proger.Send("Hello from progger");
            tester.Send("Hello from tester");

            Console.ReadLine();
        }
    }
}
