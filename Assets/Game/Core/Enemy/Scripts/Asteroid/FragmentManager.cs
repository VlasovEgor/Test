using UnityEngine;

public class FragmentManager : BaseEnemyManager, IEnemySpawner
{
    [SerializeField] private int _maxAmountFragments;

    private Vector3 _spawnPosition;
    public void SetSpawnPosition(Vector3 spawnPosition)
    {
        _spawnPosition = spawnPosition;
    }
    
    public void SpawnEnemy()
    {
        int randAmount = Random.Range(1, _maxAmountFragments + 1);
        for (int i = 0; i < randAmount; i++)
        {
            Entity enemy = _enemyPool.GetObject();
            enemy.Get<IDamagable>().OnHealthEmpty += OnEnemyDead;
            enemy.transform.position = _spawnPosition;
        }
    }
}
