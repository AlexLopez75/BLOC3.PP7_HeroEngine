namespace BLOC3.PP7_HeroEngine.models;

public class Warrior : AHero
{
    public int Armor { get; set; }
    public string BattleCry { get; set; }

    public Warrior(string name, int level, int maxHp, int power, int armor, string battleCry) : base(name, level, maxHp, power)
    {
        if (level > 1) Armor = (int)(armor + armor * 0.15 * (level - 1));
        else Armor = armor;
        BattleCry = battleCry;
    }

    public override string Greeting() => $"[Warrior] {Name} | Level: {Level} | HP: {CurrentHp}/{MaxHp} | Armor: {Armor} | Battle Cry: {BattleCry} ]";

    public override int Attack()
    {
        if (CurrentHp <= 0)
        {
            Console.WriteLine($"{Name} is defeated and can't attack!");
            return 0;
        }
        
        Console.WriteLine($"{Name} attacks! Deals {Power * 2} damage.");
        return Power * 2;
    }

    public override int TakeDamage(int damage)
    {
        if (CurrentHp <= 0)
        {
            Console.WriteLine($"{Name} is defeated and can't receive damage!");
            return 0;
        }
        int actualDamage = Math.Max(0, damage - Armor);
        CurrentHp = Math.Max(0, CurrentHp - actualDamage);
        Console.WriteLine($"{Name} receives {damage} -> Armor absorbs {Armor} damage -> Total damage: {actualDamage} | HP:{CurrentHp}/{MaxHp}");
        return CurrentHp;
    }
}