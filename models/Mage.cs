namespace BLOC3.PP7_HeroEngine.models;

public class Mage : AHero
{
    public const string toStringMSG = "| Mana: {0}/{1} | Arch level: {2}";
    
    public int CurrentMana { get; set; }
    public int MaxMana { get; set; }
    public int ArchLevel { get; set; }

    public Mage(string name, int maxMana) : base(name)
    {
        /*if (level > 1) MaxMana = (int)(baseMaxMana + baseMaxMana * 0.1 * (level - 1));
        else MaxMana = baseMaxMana;*/
        MaxHp = 200;
        CurrentHp = MaxHp;
        Power = 20;
        MaxMana = 30;
        CurrentMana = MaxMana;
        ArchLevel = 1;
    }

    public override string ToString() => base.ToString() + String.Format(toStringMSG, CurrentMana, MaxMana, ArchLevel);
}