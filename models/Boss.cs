namespace BLOC3.PP7_HeroEngine.models;

public class Boss : AEnemy
{
    public Boss(string name) : base(name)
    {
        MaxHp = 300;
        CurrentHp = MaxHp;
        Power = 45;
        Defense = 20;
    }
}