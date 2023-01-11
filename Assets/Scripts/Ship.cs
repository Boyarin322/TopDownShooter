using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public abstract class Ship : MonoBehaviour, IDamageable
{
    [SerializeField] protected float _health;
    protected bool _isAlive = true;

    public float CurrentHealth => _health;
    public virtual void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            _isAlive= false;
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }

}
