using System;
using UnityEngine;
using Zenject;

public class AsteroidManager : MonoBehaviour
{
   public event Action AsteroidDead;
    
    [SerializeField] private Transform _container;
    [SerializeField] private int _enemyPoolInitSize;
    [SerializeField] private Entity _prefab;

    private PoolObject<Entity> _enemyPool;
    private LevelBounds _levelBounds;
    
    [Inject]
    private void Construct(LevelBounds levelBounds)
    {
        _levelBounds = levelBounds;
    }
    
    private void Awake()
    {   
        GameStateManager.Instance.GameStateChanged += OnGameStateChanged;
        _enemyPool = new PoolObject<Entity>(_prefab, _container, _enemyPoolInitSize);
    }

    private void OnDestroy()
    {   
        GameStateManager.Instance.GameStateChanged -= OnGameStateChanged;
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
        
        enemy.Get<AsteroidMovement>().ChoosingDirection();
    }
    
    private void EnemyDead(Entity enemy)
    {
        _enemyPool.ReturnObject(enemy);

        enemy.Get<Health>().OnHealthEmpty -= EnemyDead;
        AsteroidDead?.Invoke();
    }
    
    private void CheckingExitEnemyBeyondLevel()
    {
        var activeEnemies = _enemyPool.GetActiveObjects();

        for (int i = 0; i < activeEnemies.Count; i++)
        {
            if (_levelBounds.InBounds(activeEnemies[i].transform.position) == false)
            {
                activeEnemies[i].transform.position = _levelBounds.NewPosition(activeEnemies[i].transform.position);
            }
        }
    }
    
    private void OnGameStateChanged(GameState state)
    {
        if (state == GameState.PAUSE)
        {
            StopEnemies();
        }
    }

    private void StopEnemies()
    {
        var activeEnemies = _enemyPool.GetActiveObjects();
        
        foreach (var enemy in activeEnemies)
        {
            enemy.Get<AsteroidMovement>().Stop();
        }
    }
}
