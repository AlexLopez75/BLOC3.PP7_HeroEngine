using BLOC3.PP7_HeroEngine.models;

namespace BLOC3.PP7_HeroEngine
{
    public class Program
    {
        public static void Main()
        {
            Warrior warrior = new Warrior("Link", "'Hyaa!'");
            Console.WriteLine(warrior.Greeting());
            warrior.Attack();
            warrior.TakeDamage(50);

            Console.WriteLine();
            
            Mage mage = new Mage("Ela", 40);
            Console.WriteLine(mage.Greeting());
            mage.Attack();
            mage.TakeDamage(50);
            
            Console.WriteLine();

            Rogue rogue = new Rogue("Elding", 10);
            Console.WriteLine(rogue.Greeting());
            rogue.Attack();
            rogue.TakeDamage(50);
        }
    }
}