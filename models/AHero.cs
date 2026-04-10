namespace BLOC3.PP7_HeroEngine.models;

public abstract class AHero
{
    public const string toStringMSG = "[{0}] {1} | Level: {2} | HP: {3}/{4} | Power: {5} ";
    public const string defAttackMSG = "{0} is defeated and can't attack!";
    public const string attackMSG = "{0} attacks! Deals {1} damage.";
    public const string defDamageMSG = "{0} is defeated and can't receive damage!";
    public const string damageMSG = "{0} receives {1} | HP: {2}/{3}";
    
    protected string Name { get; set; }
    protected int Level { get; set; }
    protected int CurrentHp { get; set; }
    protected int MaxHp { get; set; }
    protected int Power { get; set; }

    protected AHero(string name)
    {
        Name = name;
        Level = 1;
    }

    public override string ToString() => String.Format(toStringMSG, GetType().Name, Name, Level, CurrentHp, MaxHp, Power);

    /// <summary>
    /// Gets the hero's characteristic greeting or introduction phrase.
    /// </summary>
    /// <returns>A string containing the greeting.</returns>
    public string Greeting() => ToString();

    /// <summary>
    /// Calculates and executes the hero's attack based on their stats (Power).
    /// </summary>
    /// <returns>The total amount of damage the hero inflicts in this attack.</returns>
    public int Attack()
    {
        if (CurrentHp <= 0)
        {
            Console.WriteLine(defAttackMSG, Name);
            return 0;
        }
        Console.WriteLine(attackMSG, Name, Power);
        return Power;   
    }

    /// <summary>
    /// Processes the amount of damage the hero receives and updates their current health points (<see cref="CurrentHp"/>).
    /// </summary>
    /// <param name="damage">The amount of incoming damage the hero takes.</param>
    /// <returns>The hero's remaining health points after the impact, or the effective damage taken (depending on the derived class implementation).</returns>
    public int TakeDamage(int damage)
    {
        if (CurrentHp <= 0)
        {
            Console.WriteLine(defDamageMSG, Name);
            return 0;
        }
        CurrentHp = Math.Max(0, CurrentHp - damage);
        Console.WriteLine(damageMSG, Name, damage, CurrentHp, MaxHp);
        return CurrentHp;
    }
    
    /// <summary>
    /// Upgrades MaxHp and Power values.
    /// </summary>
    public void LevelUp()
    {
        MaxHp = (int)(MaxHp + MaxHp * 0.2 * (Level - 1));
        Power = (int)(Power + Power * 0.1 * (Level - 1));
    }
}