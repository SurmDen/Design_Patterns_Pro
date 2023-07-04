using System;
using System.Text.Json;
using System.Text;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Visitor
{
    public interface IBankVisitor
    {
        public void VisitPerson(Person person);
        public void VisitOrganisation(Organisation organisation);
    }

    public class JsonVisitor : IBankVisitor
    {
        public void VisitOrganisation(Organisation organisation)
        {
            Console.WriteLine(JsonSerializer.Serialize(organisation));
        }

        public void VisitPerson(Person person)
        {
            Console.WriteLine(JsonSerializer.Serialize(person));
        }
    }

    public class XMLVisitor : IBankVisitor
    {
        public void VisitOrganisation(Organisation organisation)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"<Name>{organisation.Name}</Name>");
            builder.Append(Environment.NewLine);
            builder.Append($"<Address>{organisation.Address}</Address>");
            Console.WriteLine(builder);
        }

        public void VisitPerson(Person person)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"<Name>{person.Name}</Name>");
            builder.Append(Environment.NewLine);
            builder.Append($"<Address>{person.Address}</Address>");
            Console.WriteLine(builder);
        }
    }

    public abstract class Account
    {
        public Account(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public string Name { get; set; }
        public string Address { get; set; }

        public abstract void Parse(IBankVisitor visitor);
    }

    public class Person : Account
    {
        public Person(string name, string address) : base(name, address)
        {

        }

        public override void Parse(IBankVisitor visitor)
        {
            visitor.VisitPerson(this);
        }
    }

    public class Organisation : Account
    {
        public Organisation(string name, string address) : base(name, address)
        {

        }

        public override void Parse(IBankVisitor visitor)
        {
            visitor.VisitOrganisation(this);
        }
    }

    public class Bank
    {
        List<Account> Accounts { get; set; }

        public Bank()
        {
            Accounts = new List<Account>();
        }

        public void Add(Account account)
        {
            Accounts.Add(account);
        }

        public void Delete(Account account)
        {
            Accounts.Remove(account);
        }

        public void Accept(IBankVisitor bankVisitor)
        {
            foreach (var item in Accounts)
            {
                item.Parse(bankVisitor);
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();

            Account account1 = new Organisation("SurmanCorp", "CA, yellow str.");
            Account account2 = new Person("Surman", "Spb, School str.");

            bank.Add(account1);
            bank.Add(account2);

            bank.Accept(new JsonVisitor());
            Console.WriteLine();
            bank.Accept(new XMLVisitor());


            Console.ReadLine();
        }
    }
}
