namespace BLOC3.PP7_HeroEngine.models;

public class Mage : ACharacter
{
    public const string toStringMSG = "| Mana: {0}/{1} | Arch level: {2}";
    
    public int CurrentMana { get; set; }
    public int MaxMana { get; set; }
    public int ArchLevel { get; set; }

    public Mage(string name, int maxMana) : base(name)
    {
        MaxHp = 200;
        CurrentHp = MaxHp;
        Power = 20;
        MaxMana = 30;
        CurrentMana = MaxMana;
        ArchLevel = 1;
    }

    public override string ToString() => base.ToString() + String.Format(toStringMSG, CurrentMana, MaxMana, ArchLevel);
}