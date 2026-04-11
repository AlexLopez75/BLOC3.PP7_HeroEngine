using System.Net.Http.Headers;
using BLOC3.PP7_HeroEngine.enums;
using BLOC3.PP7_HeroEngine.models;

namespace BLOC3.PP7_HeroEngine
{
    public class Program
    {
        public static void Main()
        {
            ACharacter warrior = new Warrior("Link", "'Hyaa!'");
            ACharacter mage = new Mage("Ela");
            ACharacter rogue = new Rogue("Elding", 10);

            Console.WriteLine(warrior.Greeting());
            Console.WriteLine(mage.Greeting());
            Console.WriteLine(rogue.Greeting());

            Console.WriteLine();
            
            warrior.Attack();
            mage.Attack();
            rogue.Attack();
            
            Console.WriteLine();
            
            mage.TakeDamage(30);
            rogue.TakeDamage(30);
            warrior.TakeDamage(50);
            warrior.TakeDamage(30);

            Console.WriteLine();
            
            rogue.TakeDamage(200);
            rogue.Attack();
            rogue.TakeDamage(30);
        }
    }
}