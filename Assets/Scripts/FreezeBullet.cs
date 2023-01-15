using System.Collections;
using UnityEngine;

public class FreezeBullet : Bullet
{

    [SerializeField] private float _stunDuration = 0.4f;

    private Color _baseColor;
    private Color _freezeColor = Color.cyan;

    private SpriteRenderer _collisionRenderer;
    private Rigidbody2D _collisionRb;

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        Freeze(collision);
    }
    private void Freeze(Collision2D collision)
    {
        _collisionRb = collision.gameObject.GetComponent<Rigidbody2D>();
        _collisionRenderer = collision.gameObject.GetComponent<SpriteRenderer>();

        _baseColor = _collisionRenderer.material.color;

        _collisionRenderer.material.color = _freezeColor;
        StartCoroutine(collision.FreezeCoroutine());

    }
  
}
