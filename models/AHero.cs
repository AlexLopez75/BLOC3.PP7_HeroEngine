namespace BLOC3.PP7_HeroEngine.models;

public abstract class AHero
{
    protected string Name { get; set; }
    protected int Level { get; set; }
    protected int CurrentHp { get; set; }
    protected int MaxHp { get; set; }
    protected int Power { get; set; }

    protected AHero(string name, int level, int currentHp, int maxHp, int power)
    {
        Name = name;
        Level = level;
        CurrentHp = currentHp;
        MaxHp = maxHp;
        Power = power;
    }

    public abstract string Greeting();
    public abstract int Attack();
    public abstract int TakeDamage(int damage);
}