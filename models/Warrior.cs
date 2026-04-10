using System.Globalization;

namespace BLOC3.PP7_HeroEngine.models;

public class Warrior : AHero
{
    public const string toStringMSG = "| Armor: {0} | Battle Cry: {1}";
    public const string defDamageMSG = "{0} is defeated and can't receive damage!";
    public const string damageMSG = "{0} receives {1} -> Armor absorbs {2} damage -> Total damage: {3} | HP: {4}/{5}";
    
    public int Armor { get; set; }
    public string BattleCry { get; set; }

    public Warrior(string name, string battleCry) : base(name)
    {
        BattleCry = battleCry;
        /*if (level > 1) Armor = (int)(armor + armor * 0.15 * (level - 1));
        else Armor = armor;*/
        MaxHp = 150;
        CurrentHp = MaxHp;
        Power = 30;
        Armor = 40;
    }
    
    public override string ToString() => base.ToString() + String.Format(toStringMSG, Armor, BattleCry);

    public int TakeDamage(int damage)
    {
        if (CurrentHp <= 0)
        {
            Console.WriteLine(defDamageMSG, Name);
            return 0;
        }
        int actualDamage = Math.Max(0, damage - Armor);
        CurrentHp = Math.Max(0, CurrentHp - actualDamage);
        Console.WriteLine(damageMSG, Name, damage, Armor, actualDamage, CurrentHp, MaxHp);
        return CurrentHp;
    }
}