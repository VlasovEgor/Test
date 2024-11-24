using UnityEngine;

public class UFOManager :  BaseEnemyManager, IEnemySpawner
{
    [SerializeField] private Entity _player;
    
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