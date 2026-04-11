using System.Net.Http.Headers;
using BLOC3.PP7_HeroEngine.enums;
using BLOC3.PP7_HeroEngine.models;

namespace BLOC3.PP7_HeroEngine
{
    public class Program
    {
        public static void Main()
        {
            Mage mage = new Mage("Ela");
            
            Ability fireball = new Ability(RarityType.RARE, "Fireball", AbilityType.Attack);
            Ability iceShield = new Ability(RarityType.COMMON, "Ice shield", AbilityType.Defense);
            Ability megaHeal = new Ability(RarityType.EPIC, "Mega heal", AbilityType.Healing);
            Ability attackUp = new Ability(RarityType.LEGENDARY, "Attack up", AbilityType.Support);
            
            Console.WriteLine(mage.ListAbilities(mage.AbilityDictionary.Values.ToList()));
            
            Console.WriteLine();
            
            mage.EquipAbility(fireball);
            mage.EquipAbility(iceShield);
            mage.EquipAbility(megaHeal);
            mage.EquipAbility(attackUp);
            
            Console.WriteLine();
            
            mage.EquipAbility(fireball);

            Console.WriteLine();

            Console.WriteLine(mage.ListAbilities(mage.AbilityDictionary.Values.ToList()));

            Console.WriteLine();

            mage.TakeDamage(60);
            Console.WriteLine(mage.ToString());
            mage.CastAbility(megaHeal);
            Console.WriteLine(mage.ToString());
            
            Console.WriteLine();
            
            Console.WriteLine(mage.ToString());
            mage.CastAbility(iceShield);
            Console.WriteLine(mage.ToString());
            mage.CastAbility(fireball);
            Console.WriteLine(mage.ToString());
            
            Console.WriteLine();

            mage.CastAbility(attackUp);
        }
    }
}