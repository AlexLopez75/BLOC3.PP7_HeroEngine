namespace BLOC3.PP7_HeroEngine.models;

public class Minion : AEnemy
{
    public Minion(string name) : base(name)
    {
        MaxHp = 50;
        CurrentHp = MaxHp;
        Power = 15;
        Defense = 5;
    }
}