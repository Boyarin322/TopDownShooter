using UnityEngine;


public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _firepoint;

    private Rigidbody2D _currentBulletRb;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
        
    }
    private void Shoot()
    {
        Bullet createdBullet = Instantiate(_bullet, _firepoint.position, _firepoint.rotation );
        _currentBulletRb = createdBullet.GetComponent<Rigidbody2D>();
        _currentBulletRb.AddForce(_firepoint.up * _bullet.BulletSpeed, ForceMode2D.Impulse);
    }

}
