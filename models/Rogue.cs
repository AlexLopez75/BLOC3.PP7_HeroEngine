namespace BLOC3.PP7_HeroEngine.models;

public class Rogue : AHero
{
    public int MultDamage { get; set; }
    public int NumDaggers { get; set; }

    public Rogue(string name, int level, int maxHp, int power, int multDamage, int numDaggers) : base(name, level,maxHp, power)
    {
        MultDamage = multDamage;
        NumDaggers = numDaggers;
    }

    public override string Greeting() => $"[Rogue] {Name} | Level: {Level} | HP: {CurrentHp}/{MaxHp} | Damage Multiplier: {MultDamage} | Daggers: {NumDaggers} ]";

    public override int Attack()
    {
        if (CurrentHp <= 0)
        {
            Console.WriteLine($"{Name} is defeated and can't attack!");
            return 0;
        }
        
        Console.WriteLine($"{Name} attacks! Deals {Power * MultDamage} damage.");
        return Power * MultDamage;
    }

    public override int TakeDamage(int damage)
    {
        if (CurrentHp <= 0)
        {
            Console.WriteLine($"{Name} is defeated and can't receive damage!");
            return 0;
        }
        CurrentHp = Math.Max(0, CurrentHp - damage);
        Console.WriteLine($"{Name} receives {damage} | HP:{CurrentHp}/{MaxHp}");
        return CurrentHp;
    }
}