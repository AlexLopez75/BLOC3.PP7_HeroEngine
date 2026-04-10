namespace BLOC3.PP7_HeroEngine.models;

public class Rogue : AHero
{
    public const string toStringMSG = "| Damage multiplier: {0} | Daggers: {1}";
    public const string defAttackMSG = "{0} is defeated and can't attack!";
    public const string attackMSG = "{0} attacks! -> Base damage: {1}, Multiplier: {2} -> Deals {3} damage.";

    public int MultDamage { get; set; }
    public int NumDaggers { get; set; }

    public Rogue(string name, int numDaggers) : base(name)
    {
        MaxHp = 170;
        CurrentHp = MaxHp;
        Power = 15;
        MultDamage = 3;
        NumDaggers = numDaggers;
    }

    public override string ToString() => base.ToString() + String.Format(toStringMSG, MultDamage, NumDaggers );
    
    public int Attack()
    {
        if (CurrentHp <= 0)
        {
            Console.WriteLine(defAttackMSG, Name);
            return 0;
        }
        Console.WriteLine(attackMSG, Name, Power, MultDamage, Power * MultDamage);
        return Power * MultDamage;   
    }
}