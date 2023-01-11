using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : Ship
{
    public override void TakeDamage(float damage)
    {
        _health -= damage;
        EventBus.OnTakeDamage?.Invoke();
        if (_health <= 0)
        {
            _isAlive = false;
            Die();
        }
    }
}
