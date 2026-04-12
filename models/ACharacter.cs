namespace BLOC3.PP7_HeroEngine.models;

public abstract class ACharacter
{
    public const string toStringMSG = "[{0}] {1} | Level: {2} | HP: {3}/{4} | Power: {5} | Defense: {6} ";
    public const string defAttackMSG = "{0} is defeated and can't attack!";
    public const string attackMSG = "{0} attacks! Deals {1} damage.";
    public const string defDamageMSG = "{0} is defeated and can't receive damage!";
    public const string damageMSG = "{0} receives {1} damage. | HP: {2}/{3}";
    
    public string Name { get; set; }
    protected int Level { get; set; }
    public int CurrentHp { get; set; }
    public int MaxHp { get; set; }
    protected int Power { get; set; }
    protected int Defense { get; set; }
    public bool IsDefeated => CurrentHp <= 0;
    public virtual int Initiative => Power + MaxHp + Defense;
    
    protected ACharacter(string name)
    {
        Name = name;
        Level = 1;
    }

    public override string ToString() => String.Format(toStringMSG, GetType().Name, Name, Level, CurrentHp, MaxHp, Power, Defense);

    /// <summary>
    /// Gets the hero's characteristic greeting or introduction phrase.
    /// </summary>
    /// <returns>A string containing the greeting.</returns>
    public string Greeting() => ToString();

    /// <summary>
    /// Calculates and executes the hero's attack based on their stats (Power).
    /// </summary>
    /// <returns>The total amount of damage the hero inflicts in this attack.</returns>
    public virtual int Attack()
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
    public virtual int TakeDamage(int damage)
    {
        if (CurrentHp <= 0)
        {
            Console.WriteLine(defDamageMSG, Name);
            return 0;
        }
        int actualDamage = Math.Max(0, damage - Defense);
        CurrentHp = Math.Max(0, CurrentHp - actualDamage);
        Console.WriteLine(damageMSG, Name, actualDamage, CurrentHp, MaxHp);
        return CurrentHp;
    }
    
    /// <summary>
    /// Upgrades MaxHp and Power values.
    /// </summary>
    public void LevelUp()
    {
        Level++;
        MaxHp = (int)(MaxHp + MaxHp * 0.2 * (Level - 1));
        Power = (int)(Power + Power * 0.1 * (Level - 1));
        Defense = (int)(Defense + Defense * 0.1 * (Level - 1));
        CurrentHp = MaxHp;
    }
}