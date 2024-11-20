using System;
using UnityEngine;

public sealed class Bullet : MonoBehaviour
{
    public event Action<Bullet> BulletOff;

    public Vector3 Position => transform.position;

    [SerializeField] private int _damage;
    [SerializeField] private float _speed = 3;
    [Space]
    [SerializeField] private Rigidbody2D _rigidbody2D;
    
    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void SetVelocity(Vector2 velocity)
    {
        _rigidbody2D.velocity = velocity.normalized * _speed;
    }

    public void Disable()
    {
        gameObject.SetActive(false);
        BulletOff?.Invoke(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Entity>(out var entity))
        {
            DealDamage(entity);
        }
    }

    private void DealDamage(Entity entity)
    {
        var damageable = entity.Get<Health>();
        if (damageable != null)
        {
            damageable.TakeDamage(_damage);
            BulletOff?.Invoke(this);
        }
    }
}