using UnityEngine;

public class AsteroidManager : BaseEnemyManager, IEnemySpawner
{
    [SerializeField] private FragmentManager _fragmentManager;

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
    }

    protected override void OnEnemyDead(Entity enemy)
    {   
        _fragmentManager.SetSpawnPosition(enemy.transform.position);
        _fragmentManager.SpawnEnemy();
        
        base.OnEnemyDead(enemy);
    }
}