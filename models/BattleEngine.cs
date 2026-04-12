namespace BLOC3.PP7_HeroEngine.models;

public class BattleEngine
{
    private const string separator = "======================================================";
    private const string battleStartMSG = "                    BATTLE STARTS                     ";
    private const string roundMSG = "\n============== BATTLE LOG - Round {0} ===============";
    private const string heroWinMSG = "                   THE HEROES WIN!                    ";
    private const string enemyWinMSG = "                THE PRIMORDIAL BUG WINS!                 ";
    private const string expLevelUPMSG = "[SYSTEM] The experience of the battle makes the suvivors stronger!";
    private const string heroLevelUPMSG = "[SYSTEM] {0} levelled up to Level {1}!";
    
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
        BattleLogger.Initialize();
        
        BattleLogger.Log(separator);
        BattleLogger.Log(battleStartMSG);
        BattleLogger.Log(separator);
        
        while (!IsBattleFinished())
        {
            PlayRound();
            _countRound++;
        }
        AnounceWinner();
    }

    private void PlayRound()
    {
        BattleLogger.Log(string.Format(roundMSG, _countRound));
        
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
        BattleLogger.Log("");
        BattleLogger.Log(separator);
        if (_enemies.All(e => e.IsDefeated))
        {
            BattleLogger.Log(heroWinMSG);
            BattleLogger.Log(expLevelUPMSG);
            foreach (var hero in _heroes)
            {
                if (!hero.IsDefeated)
                {
                    if (hero is AHero survivingHero)
                    {
                        survivingHero.LevelUp();
                        BattleLogger.Log(String.Format(heroLevelUPMSG, survivingHero.Name, survivingHero.Level));
                    }
                }
            }
        }
        else
        {
            BattleLogger.Log(enemyWinMSG);
        }
        BattleLogger.Log(separator);
    }
}