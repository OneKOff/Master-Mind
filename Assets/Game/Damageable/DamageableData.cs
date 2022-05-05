using UnityEngine;

[CreateAssetMenu(fileName = "Damageable Data", menuName = "Entity/Damageable Data")]
public class DamageableData : ScriptableObject
{
    public int MaxHealth;
    public int HealthRegen;
}
