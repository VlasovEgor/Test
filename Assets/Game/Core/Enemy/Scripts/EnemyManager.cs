using UnityEngine;
using Zenject;

public sealed class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _enemyPoolInitSize;
    [SerializeField] private Entity _prefab;
    [SerializeField] private Entity _player;

    private PoolObject<Entity> _enemyPool;
    private LevelBounds _levelBounds;
    
    [Inject]
    private void Construct(LevelBounds levelBounds)
    {
        _levelBounds = levelBounds;
    }
    
    private void Awake()
    {
        _enemyPool = new PoolObject<Entity>(_prefab, _container, _enemyPoolInitSize);
    }

    private void Update()
    {
        CheckingExitEnemyBeyondLevel();
    }
    
    public void SpawnEnemy()
    {
        Entity enemy = _enemyPool.GetObject();
        SetupEnemy(enemy);
    }

    private void SetupEnemy(Entity enemy)
    {
        enemy.Get<Health>().OnHealthEmpty += EnemyDead;
        Vector3 spawnPosition = _levelBounds.GetRandomPointOnBounds();
        enemy.transform.position = spawnPosition;
        
        enemy.Get<EnemyMovement>().SetTarget(_player.transform);
    }
    
    private void EnemyDead(Entity enemy)
    {
        _enemyPool.ReturnObject(enemy);

        enemy.Get<Health>().OnHealthEmpty -= EnemyDead;
    }
    
    private void CheckingExitEnemyBeyondLevel()
    {
        var activeBullet = _enemyPool.GetActiveObjects();

        for (int i = 0; i < activeBullet.Count; i++)
        {
            if (_levelBounds.InBounds(activeBullet[i].transform.position) == false)
            {
                activeBullet[i].transform.position = _levelBounds.NewPosition(activeBullet[i].transform.position);
            }
        }
    }
}