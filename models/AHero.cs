namespace BLOC3.PP7_HeroEngine.models;

public abstract class AHero
{
    protected string Name { get; set; }
    protected int Level { get; set; }
    protected int CurrentHp { get; set; }
    protected int MaxHp { get; set; }
    protected int Power { get; set; }

    protected AHero(string name, int level, int baseMaxHp, int basePower)
    {
        Name = name;
        Level = level;
        if (level > 1)
        {
            MaxHp = (int)(baseMaxHp + baseMaxHp * 0.2 * (level - 1));
            Power = (int)(basePower + basePower * 0.1 * (level - 1));
        }
        else
        {
            MaxHp = baseMaxHp;
            Power = basePower;
        }
        CurrentHp = MaxHp;
    }

    public abstract string Greeting();
    public abstract int Attack();
    public abstract int TakeDamage(int damage);
}