using System;
using System.Collections;
using System.Collections.Generic;


namespace Interpreter
{
    //save receive data and save output data
    public class Context
    {
        public string Input { get; set; }

        public int Output { get; set; }

        public Context(string input)
        {
            Input = input;
        }
    }

    //abstraction for EXPRESSION
    public abstract class Expression
    {
        public void Interpret(Context context)
        {
            if (context.Input.Length == 0)
            {
                return;
            }

            if (context.Input.StartsWith(Nine()))
            {
                context.Output += 9* Multiplier();
                context.Input = context.Input.Substring(2);
            }
            
            else if (context.Input.StartsWith(Four()))
            {
                context.Output += 4* Multiplier();
                context.Input = context.Input.Substring(2);
            }

            else if (context.Input.StartsWith(Five()))
            {
                context.Output += 5 * Multiplier();
                context.Input = context.Input.Substring(1);
            }

            while (context.Input.StartsWith(One()))
            {
                context.Output += Multiplier();
                context.Input = context.Input.Substring(1);
            }
        }

        public abstract string One();
        public abstract string Four();
        public abstract string Five();
        public abstract string Nine();
        public abstract int Multiplier();
    }

    public class ThousandsExpression: Expression
    {
        public override int Multiplier()
        {
            return 1000;
        }

        public override string One()
        {
            return "M";
        }

        public override string Four()
        {
            return "";
        }

        public override string Five()
        {
            return "";
        }

        public override string Nine()
        {
            return "";
        }
    }

    public class HundreadsExpression : Expression
    {
        public override int Multiplier()
        {
            return 100;
        }

        public override string One()
        {
            return "C";
        }

        public override string Four()
        {
            return "CD";
        }

        public override string Five()
        {
            return "D";
        }

        public override string Nine()
        {
            return "CM";
        }
    }

    public class TensExpression : Expression
    {
        public override int Multiplier()
        {
            return 10;
        }

        public override string One()
        {
            return "X";
        }

        public override string Four()
        {
            return "XL";
        }

        public override string Five()
        {
            return "L";
        }

        public override string Nine()
        {
            return "XC";
        }
    }

    public class OnesExpression : Expression
    {
        public override int Multiplier()
        {
            return 1;
        }

        public override string One()
        {
            return "I";
        }

        public override string Four()
        {
            return "IV";
        }

        public override string Five()
        {
            return "V";
        }

        public override string Nine()
        {
            return "IX";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string roman = "MDCXLVIII";

            Context context = new Context(roman);

            List<Expression> tree = new List<Expression>()
            {
                new ThousandsExpression(),
                new HundreadsExpression(),
                new TensExpression(),
                new OnesExpression()
            };

            foreach (Expression exp in tree)
            {
                exp.Interpret(context);
            }


            Console.WriteLine($"{roman} --- {context.Output}");

            Console.ReadLine();
        }
    }
}
