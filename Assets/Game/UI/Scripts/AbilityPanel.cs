using UnityEngine;
using System.Collections;

public class AbilityPanel : MonoBehaviour
{
    public AbilityUI[] AbilityButtons;

    public void SetAbilities(AbilityType[] abilities)
    {
        for (var i = 0; i < AbilityButtons.Length; i++)
        {
            AbilityButtons[i].HeldAbility = abilities[i];
        }
    }
}
