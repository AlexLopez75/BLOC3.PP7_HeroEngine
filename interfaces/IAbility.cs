using BLOC3.PP7_HeroEngine.models;

namespace BLOC3.PP7_HeroEngine.interfaces;

public interface IAbility
{
    public void CastAbility(Ability ability);
    public string ListAbilities(List<Ability> listAbilities);
    public void EquipAbility(Ability ability);
}