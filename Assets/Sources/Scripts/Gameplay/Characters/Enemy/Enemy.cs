using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    private Health _health;

    private void Awake()
    {
        _health = new Health(100, 100);
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }
}
