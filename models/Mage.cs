using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLOC3.PP7_HeroEngine.enums;
using BLOC3.PP7_HeroEngine.interfaces;

namespace BLOC3.PP7_HeroEngine.models;

public class Mage : ACharacter, IAbility
{
    public const string toStringMSG = "| Mana: {0}/{1} | Arch level: {2}";
    public const string notEnoughManaMSG = "{0} can't cast '{1}' beacuse it doesn't have enough mana! (Needs {2}, has {3})";
    public const string abilityActivationMSG = "Activating '{0}' [{1}]...";
    public const string abilityAttackMSG = "{0} deals massive damage -> Total damage: {1}";
    public const string abilityDefenseMSG = "{0} shields itself from {1} damage.";
    public const string abilityHealMSG = "{0} heals {1} damage.";
    public const string abilitySupportMSG = "{0} strenghtens itself.";
    public const string noAbilitiesMSG = "{0} has no abilities equiped.";
    public const string separator = "--------------------------------------------------------------------";
    public const string abilitiesTitleMSG = "{0}'s Abilities";
    public const string abilityRepeat = "[System] {0} has already '{1}' equiped";
    public const string abilityEquip = "[System] {0} equipped '{1}'";
    
    public int CurrentMana { get; set; }
    public int MaxMana { get; set; }
    public int ArchLevel { get; set; }
    public Dictionary<string, Ability> AbilityDictionary { get; private set; } = new Dictionary<string, Ability>();
    
    public Mage(string name) : base(name)
    {
        MaxHp = 200;
        CurrentHp = MaxHp;
        Power = 20;
        Defense = 20;
        MaxMana = 80;
        CurrentMana = MaxMana;
        ArchLevel = 1;
    }

    public override string ToString() => base.ToString() + String.Format(toStringMSG, CurrentMana, MaxMana, ArchLevel);
    
    /// <summary>
    /// Executes the Mage's combat turn automatically based on current health, mana, and equipped abilities.
    /// </summary>
    /// <remarks>
    /// The attack logic follows a strict priority system:
    /// <list type="number">
    /// <item><description><b>Survival:</b> If HP drops below 40%, attempts to cast the highest-power Healing ability available.</description></item>
    /// <item><description><b>Tactical:</b> If Mana is above 70%, attempts to cast a Defense or Support ability to buff stats.</description></item>
    /// <item><description><b>Offense:</b> Attempts to cast the highest-power Attack ability.</description></item>
    /// <item><description><b>Fallback:</b> If no abilities are equipped or there is insufficient mana, performs a basic physical attack.</description></item>
    /// </list>
    /// </remarks>
    /// <returns>
    /// The amount of damage dealt to an opponent. Returns <c>0</c> if the Mage is defeated, or if the turn was spent healing or buffing instead of attacking.
    /// </returns>
    public override int Attack()
    {
        if (IsDefeated)
        {
            Console.WriteLine(defAttackMSG, Name);
            return 0;
        }
        
        //First, looks to heal if health is below 40%
        if (CurrentHp < MaxHp * 0.4)
        {
            var healAbility = AbilityDictionary.Values
                .Where(a => a.Type == AbilityType.Healing && CurrentMana >= a.Cost)
                .OrderByDescending(a => a.AbilityPower)
                .FirstOrDefault();

            if (healAbility != null)
            {
                CurrentMana -= healAbility.Cost;
                Console.WriteLine(abilityActivationMSG, healAbility.Name, healAbility.Rarity);
                
                CurrentHp = Math.Min(MaxHp, CurrentHp + healAbility.AbilityPower);
                Console.WriteLine(abilityHealMSG, Name, healAbility.AbilityPower);
                
                return 0;
            }
        }

        //If has greater than 70% of mana, tries to buff himself.
        if (CurrentMana > MaxMana * 0.7)
        {
            var supportAbility = AbilityDictionary.Values
                .Where(a => (a.Type == AbilityType.Defense || a.Type == AbilityType.Support) && CurrentMana >= a.Cost)
                .FirstOrDefault();

            if (supportAbility != null)
            {
                CurrentMana -= supportAbility.Cost;
                Console.WriteLine(abilityActivationMSG, supportAbility.Name, supportAbility.Rarity);

                if (supportAbility.Type == AbilityType.Defense)
                {
                    Defense += supportAbility.AbilityPower;
                    Console.WriteLine(abilityDefenseMSG, Name, supportAbility.AbilityPower);
                }
                else
                {
                    Power += supportAbility.AbilityPower;
                    Console.WriteLine(abilitySupportMSG, Name);
                }
                return 0;
            }
        }
        
        //If not heal or buff, attacks
        var attackAbility =  AbilityDictionary.Values
            .Where(a => a.Type == AbilityType.Attack && CurrentMana >= a.Cost)
            .OrderByDescending(a => a.AbilityPower)
            .FirstOrDefault();

        if (attackAbility != null)
        {
            CurrentMana -= attackAbility.Cost;
            Console.WriteLine(abilityActivationMSG, attackAbility.Name, attackAbility.Rarity);
            int totalDamage = Power + attackAbility.AbilityPower;
            Console.WriteLine(abilityAttackMSG, Name, totalDamage);
            return totalDamage;
        }
        
        if (AbilityDictionary.Count == 0) //If equipped abilities, normal attack.
        {
            Console.WriteLine(noAbilitiesMSG, Name);
        }
        else
        {
            //Searches the best attack regardless of mana to say why it didn't use it
            var bestAttack = AbilityDictionary.Values
                .Where(a => a.Type == AbilityType.Attack)
                .OrderByDescending(a => a.AbilityPower)
                .FirstOrDefault();
            
            //If exists, it didn't laucnh beacuse Cost > CurrentMana
            if (bestAttack != null)
            {
                Console.WriteLine(notEnoughManaMSG, Name, bestAttack.Name, bestAttack.Cost, CurrentMana);
            }
        }
        
        //If not enough mana or equipped abilities, normal attack.
        return base.Attack();
    }

    /// <inheritdoc />
    public int CastAbility(Ability ability)
    {
        if (CurrentMana < ability.Cost)
        {
            Console.WriteLine(notEnoughManaMSG, Name, ability.Name, ability.Cost, CurrentMana);
            return 0;
        }
        
        CurrentMana -= ability.Cost;
        
        Console.WriteLine(abilityActivationMSG, ability.Name, ability.Rarity);

        switch (ability.Type)
        {
            case AbilityType.Attack:
                int totalDamage = Power + ability.AbilityPower;
                Console.WriteLine(abilityAttackMSG, Name, totalDamage);
                return totalDamage;
            case AbilityType.Defense:
                Defense += ability.AbilityPower;
                Console.WriteLine(abilityDefenseMSG, Name, ability.AbilityPower);
                break;
            case AbilityType.Healing:
                CurrentHp = Math.Min(MaxHp, CurrentHp + ability.AbilityPower);
                Console.WriteLine(abilityHealMSG, Name, ability.AbilityPower);
                break;
            case AbilityType.Support:
                Power += ability.AbilityPower;
                Console.WriteLine(abilitySupportMSG, Name);
                break;
        }

        return base.Attack();
    }

    /// <inheritdoc />
    public string ListAbilities(List<Ability> listAbilities)
    {
        if (listAbilities == null || listAbilities.Count == 0)
        {
            return String.Format(noAbilitiesMSG, Name);
        }
        
        var sortedAbilites = listAbilities.OrderBy(a => a.Rarity).ToList();
        
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(separator);
        sb.AppendLine(String.Format(abilitiesTitleMSG, Name));
        sb.AppendLine(separator);
        sortedAbilites.ForEach(a => sb.AppendLine(a.ToString()));
        sb.AppendLine(separator);
        
        return sb.ToString();
    }
    
    /// <inheritdoc />
    public void EquipAbility(Ability newAbility)
    {
        if (!AbilityDictionary.TryAdd(newAbility.Name, newAbility)) //If Name already exists, TryAdd returns false.
        {
            Console.WriteLine(abilityRepeat, Name, newAbility.Name);
        }
        else
        {
            Console.WriteLine(abilityEquip, Name, newAbility.Name);
        }
    }
}