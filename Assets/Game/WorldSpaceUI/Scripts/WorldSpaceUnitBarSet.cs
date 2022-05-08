using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class WorldSpaceUnitBarSet : MonoBehaviour
{
    public Slider HealthBar;
    public Text HealthRegenText;
    public Slider EnergyBar;
    public Text EnergyRegenText;
    public Slider TimeBar;
    public GameObject[] Cards = new GameObject[CardDeckManager.HAND_SIZE];
    public List<GameObject> TeamUnitIdentifiers = new List<GameObject>();

    public void ChangeStats(UnitStats stats)
    {
        HealthBar.maxValue = stats.MaxHealth;
        HealthBar.value = stats.Health;
        HealthRegenText.text = $"+{stats.HealthRegen}/t";

        EnergyBar.maxValue = stats.MaxEnergy;
        EnergyBar.value = stats.Energy;
        EnergyRegenText.text = $"+{stats.EnergyRegen}/t";

        TimeBar.maxValue = stats.MaxTime;
        TimeBar.value = stats.Time;

        for (var i = 0; i < CardDeckManager.HAND_SIZE; i++)
        {
            Cards[i].SetActive(stats.CardDeckManager.HandPile[i] == null);
        }

        IsUsableUnit(stats.TeamId == GameMainManager.Instance.TurnManager.CurrentTeamId);
    }

    public void IsUsableUnit(bool isUsable)
    {
        foreach (var identifier in TeamUnitIdentifiers)
        {
            identifier.SetActive(isUsable);
        }
    }
}
