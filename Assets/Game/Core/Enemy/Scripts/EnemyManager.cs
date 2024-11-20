using UnityEngine;
using Random = UnityEngine.Random;


public sealed class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPositions;
    [SerializeField] private Transform[] _attackPositions;
    [SerializeField] private Transform _container;
    [SerializeField] private int _enemyPoolInitSize;
    [SerializeField] private Entity _prefab;

    private PoolObject<Entity> _enemyPool;

    private void Awake()
    {
        _enemyPool = new PoolObject<Entity>(_prefab, _container, _enemyPoolInitSize);
    }

    public void SpawnEnemy()
    {
        Entity enemy = _enemyPool.GetObject();
        SetupEnemy(enemy);
    }

    private void SetupEnemy(Entity enemy)
    {
        enemy.Get<Health>().OnHealthEmpty += EnemyDead;
        Transform spawnPosition = RandomPoint(_spawnPositions);
        enemy.Transform.position = spawnPosition.position;

        Transform attackPosition = RandomPoint(_attackPositions);
        enemy.Get<EnemyMovementBehaviour>().SetDestination(attackPosition.position);
    }

    private Transform RandomPoint(Transform[] points)
    {
        int index = Random.Range(0, points.Length);
        return points[index];
    }
    
    private void EnemyDead(Entity enemy)
    {
        _enemyPool.ReturnObject(enemy);

        enemy.Get<Health>().OnHealthEmpty -= EnemyDead;
    }
}