using BLOC3.PP7_HeroEngine.models;

namespace BLOC3.PP7_HeroEngine
{
    public class Program
    {
        public static void Main()
        {
            Warrior warrior = new Warrior("Link", 10, 100, 8, 10, "'Hyaa!'");
            Console.WriteLine(warrior.Greeting());
            warrior.Attack();
            warrior.TakeDamage(50);
        }
    }
}