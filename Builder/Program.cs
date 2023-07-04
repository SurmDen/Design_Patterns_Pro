using System;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{

    //component of bread
    public class Flour
    {
        public string Sort { get; set; }
    }

    //component of bread
    public class Salt
    {

    }

    //component of bread
    public class Additives
    {
        public string Name { get; set; }
    }

    //the shief class that we shold create(may be lot's of realizations)
    public class Bread
    {
        public Salt Salt { get; set; }
        public Flour Flour { get; set; }
        public Additives Additives { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            if (Flour!= null)
            {
                builder.Append($"Flour:  {Flour.Sort} \n");
            }
            if (Salt!=null)
            {
                builder.Append("Salt \n");
            }
            if (Additives!=null)
            {
                builder.Append($"Additives: {Additives.Name} \n");
            }


            return builder.ToString();

        }
    }

    //specific class that baking only rye bread
    public class RyeBreadBuilder : BreadBuilder
    {
        public override void SetAdditives()
        {
            Bread.Additives = new Additives { Name = "Antioxydatin" };
        }

        public override void SetFlour()
        {
            Bread.Flour = new Flour { Sort = "Rye Flour" };
        }

        public override void SetSalt()
        {
            
        }
    }

    //specific class that baking only wheet bread
    public class WheetBreadBuilder : BreadBuilder
    {
        public override void SetAdditives()
        {
            Bread.Additives = new Additives { Name = "Gluten" };
        }

        public override void SetFlour()
        {
            Bread.Flour = new Flour { Sort = "Wheet Flour" };
        }

        public override void SetSalt()
        {
            Bread.Salt = new Salt();
        }
    }

    //abstract class for baking all types of bread
    public abstract class BreadBuilder
    {
        public Bread Bread { get;private set; }

        public void CreateBread()
        {
            Bread = new Bread();
        }

        public abstract void SetFlour();
        public abstract void SetSalt();
        public abstract void SetAdditives();
    }

    //the sheff baker that employ the specific bread builder and gives us tasty bread!
    public class Baker
    {
        private BreadBuilder BreadBuilder;

        public Baker(BreadBuilder breadBuilder)
        {
            BreadBuilder = breadBuilder;
        }

        public Bread CreateBread()
        {
            BreadBuilder.CreateBread();
            BreadBuilder.SetAdditives();
            BreadBuilder.SetSalt();
            BreadBuilder.SetFlour();

            return BreadBuilder.Bread;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IProductBuilder productBuilder = new ProductBuilder();

            Director director = new Director(productBuilder);

            director.ConstructProduct();

            Product product = productBuilder.GetProduct();

            //let's try our version of pattern

            BreadBuilder breadBuilder = new RyeBreadBuilder();

            Baker baker = new Baker(breadBuilder);

            Bread bread = baker.CreateBread();

            Console.WriteLine(bread.ToString());

            Console.ReadLine();
        }
    }
}
