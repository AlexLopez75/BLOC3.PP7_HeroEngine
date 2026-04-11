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

    public void CastAbility(Ability ability)
    {
        if (CurrentMana < ability.Cost)
        {
            Console.WriteLine(notEnoughManaMSG, Name, ability.Name, ability.Cost, CurrentMana);
            return;
        }
        
        CurrentMana -= ability.Cost;
        
        Console.WriteLine(abilityActivationMSG, ability.Name, ability.Rarity);

        switch (ability.Type)
        {
            case AbilityType.Attack:
                int totalDamage = Power + ability.AbilityPower;
                Console.WriteLine(abilityAttackMSG, Name, totalDamage);
                break;
            case AbilityType.Defense:
                Defense += ability.AbilityPower;
                Console.WriteLine(abilityDefenseMSG, Name, ability.AbilityPower);
                break;
            case AbilityType.Healing:
                CurrentHp = Math.Min(MaxHp, CurrentHp + ability.AbilityPower);
                Console.WriteLine(abilityHealMSG, Name, ability.AbilityPower);
                break;
            case AbilityType.Support:
                int attackBuff = Power * (ability.AbilityPower/10);
                Console.WriteLine(abilitySupportMSG, Name);
                break;
        }
    }

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