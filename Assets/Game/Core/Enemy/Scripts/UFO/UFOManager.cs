using UnityEngine;
using Zenject;

public class UFOManager :  BaseEnemyManager, IEnemySpawner
{
    private Entity _player;
    
    [Inject]
    private void Construct(Entity player)
    {
        _player = player;
    }
    
    public void SpawnEnemy()
    {
        Entity enemy = _enemyPool.GetObject();
        SetupEnemy(enemy);
    }

    private void SetupEnemy(Entity enemy)
    {
        enemy.Get<IDamagable>().OnHealthEmpty += OnEnemyDead;
        Vector3 spawnPosition = _levelBounds.GetRandomPointOnBounds();
        enemy.transform.position = spawnPosition;
        SetupEnemyMovement(enemy);
    }

    private void SetupEnemyMovement(Entity enemy)
    {
        enemy.Get<UFOMovement>().SetTarget(_player.transform);
    }
}