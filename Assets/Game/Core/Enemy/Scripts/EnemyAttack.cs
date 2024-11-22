using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int _damage;
    [Space] [SerializeField] private ColliderProxy _colliderProxy;

    private void Start()
    {
        _colliderProxy.OnCollisionEntered += HandleCollisionEnter;
    }

    private void OnDestroy()
    {
        _colliderProxy.OnCollisionEntered -= HandleCollisionEnter;
    }

    private void HandleCollisionEnter(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<Entity>(out var entity))
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
        }
    }
}
