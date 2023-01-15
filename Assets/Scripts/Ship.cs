using System.Collections;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class Ship : MonoBehaviour, IDamageable
{
    [SerializeField] protected float _health;
    [SerializeField] protected Color _shipColor;
    protected SpriteRenderer _spriteRenderer;
    protected bool _isAlive = true;

    public float CurrentHealth => _health;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
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
    public IEnumerator FreezeCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        _spriteRenderer.material.color = _shipColor;
        Debug.Log("Succes");
    }
}
