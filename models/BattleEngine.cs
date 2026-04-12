namespace BLOC3.PP7_HeroEngine.models;

public class BattleEngine
{
    private const string separator = "\n======================================================";
    private const string battleStartMSG = "                       BATTLE STARTS                     ";
    private const string roundMSG = "\n============== BATTLE LOG - Round {0} ===============";
    private const string heroWinMSG = "                      THE HEROES WIN!                    ";
    private const string enemyWinMSG = "                THE PRIMORDIAL BUG WINS!                 ";
    
    private List<ACharacter> _heroes;
    private List<ACharacter> _enemies;
    private int _countRound;

    public BattleEngine(List<ACharacter> heroes, List<ACharacter> enemies)
    {
        _heroes = heroes;
        _enemies = enemies;
        _countRound = 1;
    }

    public void StartBattle()
    {
        while (!IsBattleFinished())
        {
            PlayRound();
            _countRound++;
        }
        AnounceWinner();
    }

    private void PlayRound()
    {
        var allCombatants = new List<ACharacter>();
        allCombatants.AddRange(_heroes.Where(h => !h.IsDefeated));
        allCombatants.AddRange(_enemies.Where(e => !e.IsDefeated));

        var turnOrder = allCombatants.OrderByDescending(c => c.Initiative);

        foreach (var combatant in turnOrder)
        {
            if (IsBattleFinished()) break; //If combat ends in the middle of the round, exit.
            
            if (combatant.IsDefeated) continue; //Prevents combatants from attacking while defeated.
            
            ACharacter target = GetTarget(combatant);

            if (target != null)
            {
                int damage = combatant.Attack();
                target.TakeDamage(damage);
            }
        }
    }

    private ACharacter GetTarget(ACharacter combatant)
    {
        if (_heroes.Contains(combatant))
        {
            return _enemies.FirstOrDefault(e => !e.IsDefeated);
        }
        else
        {
            return _heroes.FirstOrDefault(h => !h.IsDefeated);
        }
    }  
    
    public bool IsBattleFinished()
    {
        bool allHeroesDefeated = _heroes.All(h => h.IsDefeated);
        bool allEnemiesDefeated = _enemies.All(e => e.IsDefeated);

        return allHeroesDefeated || allEnemiesDefeated;
    }

    private void AnounceWinner()
    {
        Console.WriteLine(separator);
        if (_heroes.All(e => !e.IsDefeated))
        {
            Console.WriteLine(heroWinMSG);
        }
        else
        {
            Console.WriteLine(enemyWinMSG);
        }
        Console.WriteLine(separator);
    }
}