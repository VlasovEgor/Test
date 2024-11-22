using System;
using UnityEngine;

public sealed class Bullet : MonoBehaviour
{
    public event Action<Bullet> BulletOff;

    [SerializeField] private int _damage;
    [SerializeField] private float _speed = 3;
    [Space]
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Timer _timer;

    private void Start()
    {
        _timer.OnEnded += Disable;
    }

    private void OnDestroy()
    {
        _timer.OnEnded -= Disable;
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        
        _timer.ResetTime();
        _timer.Play();
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void SetVelocity(Vector2 velocity)
    {
        _rigidbody2D.velocity = velocity.normalized * _speed;
    }

    private void Disable()
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
        var health = entity.Get<Health>();
        if (health != null)
        {
            health.TakeDamage(_damage);
            BulletOff?.Invoke(this);
        }
    }

    public void Stop()
    {
        _rigidbody2D.velocity = Vector2.zero;
        _timer.Stop();
    }
}