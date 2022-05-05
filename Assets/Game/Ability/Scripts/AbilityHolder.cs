[System.Serializable]
public class AbilityHolder
{
    public AbilityType AbilityType;
    public Ability Ability;

    public bool Matches(AbilityType type)
    {
        return AbilityType == type;
    }
}