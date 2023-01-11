using System.Collections;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _firepoint;

    [Space]
    [SerializeField] private Player _player;

    [Space]
    [SerializeField] private float _attackSpeed = 1f;
    private bool _isOnCooldown = false;
    private Rigidbody2D _currentBulletRb;

    private float _distanceBetweenPlayerAndEnemy;
    private float _minDistanceToShoot = 9f;



    private void FixedUpdate()
    {
        if (_player != null)
        {
            _distanceBetweenPlayerAndEnemy = Vector2.Distance(transform.position, _player.gameObject.transform.position);
            if ((_distanceBetweenPlayerAndEnemy < _minDistanceToShoot))
            {
                Shoot();
            }
        }
    }
    private void Shoot()
    {
        if (_isOnCooldown == false)
        {
            _isOnCooldown = true;
            StartCoroutine(Cooldown());

            Bullet createdBullet = Instantiate(_bullet, _firepoint.position, _firepoint.rotation);
            _currentBulletRb = createdBullet.GetComponent<Rigidbody2D>();
            _currentBulletRb.AddForce(_firepoint.up * _bullet.BulletSpeed, ForceMode2D.Impulse);
        }
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(_attackSpeed);
        _isOnCooldown = false;
    }
}
