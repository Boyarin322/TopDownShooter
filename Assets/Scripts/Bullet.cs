using UnityEngine;

public abstract class Bullet : MonoBehaviour, IBullet
{
    [SerializeField] protected float _bulletSpeed = 25f;
    [SerializeField] protected float bulletDamage = 0.2f;
    public float BulletSpeed => _bulletSpeed;

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out var idamageable))
        {
            idamageable.TakeDamage(bulletDamage);
        }
        Destroy(gameObject);
    }
 
}
