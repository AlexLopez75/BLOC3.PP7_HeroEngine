namespace BLOC3.PP7_HeroEngine.models;

public class Mage : AHero
{
    public int CurrentMana { get; set; }
    public int MaxMana { get; set; }
    public int ArchLevel { get; set; }

    public Mage(string name, int level, int maxHp, int power, int baseMaxMana, int arcLevel) : base(name, level, maxHp, power)
    {
        if (level > 1) MaxMana = (int)(baseMaxMana + baseMaxMana * 0.1 * (level - 1));
        else MaxMana = baseMaxMana;
        CurrentMana = MaxMana;
        ArchLevel = arcLevel;
    }

    public override string Greeting() => $"[Mage] {Name} | Level: {Level} | HP: {CurrentHp}/{MaxHp} | Mana: {CurrentMana}/{MaxMana} | Arch Level: {ArchLevel} ]";
    
    
    public override int Attack()
    {
        if (CurrentHp <= 0)
        {
            Console.WriteLine($"{Name} is defeated and can't attack!");
            return 0;
        }
        
        Console.WriteLine($"{Name} attacks! Deals {Power * 2} damage.");
        return Power;
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