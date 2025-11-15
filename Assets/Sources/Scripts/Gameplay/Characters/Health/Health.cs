using UnityEngine;

public class Health : IHealth
{
    private float _max;
    private float _current = 0;

    public Health(float max, float current = 0)
    {
        _max = max;
        _current = current;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;

        _current = Mathf.Clamp(_current - damage, 0, _max);

        Debug.Log(_current + " HP");

        if (_current < 0)
            Die();
    }

    public void Die()
    {
        Debug.Log("DEAD someone");
    }
}
