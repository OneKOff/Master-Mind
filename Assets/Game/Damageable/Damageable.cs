using UnityEngine;

public class Damageable : Selectable
{
    [SerializeField] protected int maxHealth;
    protected int _health;

    protected virtual void Start()
    {
        _health = maxHealth;
    }

    public virtual void ChangeHealth(int value)
    {
        _health = Mathf.Clamp(_health + value, 0, maxHealth);

        if (_health <= 0)
        {
            Die();
        }
        if (value < 0)
        {
            Debug.Log(name + " took " + value + " points of damage (" + _health + " / " + maxHealth + ")");
            // Damage Indication
        }
    }
    protected virtual void Die()
    {
        Debug.Log(name + " has been defeated.");
        Destroy(gameObject);
    }
}
