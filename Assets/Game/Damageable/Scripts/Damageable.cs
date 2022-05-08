using UnityEngine;

public class Damageable : Selectable
{
    [SerializeField] private DamageableData damageableData;
    public DamageableData DamageableData => damageableData;

    public DamageableStats DamageableStats { get; private set; }

    protected override void Start()
    {
        base.Start();

        DamageableStats = new DamageableStats();

        DamageableStats.MaxHealth = damageableData.MaxHealth;
        DamageableStats.Health = damageableData.MaxHealth;
        DamageableStats.HealthRegen = damageableData.HealthRegen;
    }

    public void ChangeHealth(int value)
    {
        DamageableStats.Health = Mathf.Clamp(DamageableStats.Health + value, 0, DamageableStats.MaxHealth);

        if (DamageableStats.Health <= 0)
        {
            Die();
        }
        if (value < 0)
        {
            Debug.Log($"{name} took {value} points of damage ({DamageableStats.Health} / {DamageableStats.MaxHealth})");
            // Damage Indication
        }
    }
    protected void Die()
    {
        Debug.Log($"{name} has been defeated.");
        Destroy(gameObject);
    }
}
