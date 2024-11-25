using System;
using UnityEngine;
using Zenject;

public interface IEnemySpawner
{
    void SpawnEnemy();
}

public abstract class BaseEnemyManager : MonoBehaviour
{
    public event Action<EnemyType> EnemyDied;
    
    [SerializeField] private Transform _container;
    [SerializeField] private int _enemyPoolInitSize;
    [SerializeField] private Entity _prefab;
    [SerializeField] private EnemyType _type;
    
    protected PoolObject<Entity> _enemyPool;
    protected LevelBounds _levelBounds;

    [Inject]
    private void Construct(LevelBounds levelBounds)
    {
        _levelBounds = levelBounds;
    }

    protected virtual void Awake()
    {
        GameStateManager.Instance.GameStateChanged += OnGameStateChanged;
        _enemyPool = new PoolObject<Entity>(_prefab, _container, _enemyPoolInitSize);
    }

    protected virtual void OnDestroy()
    {
        GameStateManager.Instance.GameStateChanged -= OnGameStateChanged;
    }

    protected virtual void Update()
    {
        CheckingExitEnemyBeyondLevel();
    }

    private void CheckingExitEnemyBeyondLevel()
    {
        var activeEnemies = _enemyPool.GetActiveObjects();
        for (int i = 0; i < activeEnemies.Count; i++)
        {
            Vector3 position = activeEnemies[i].transform.position;
            if (_levelBounds.InBounds(position) == false)
            {
                activeEnemies[i].transform.position = _levelBounds.NewMirroredPosition(position);
            }
        }
    }

    private void OnGameStateChanged(GameState newState)
    {
        if (newState == GameState.PAUSE)
        {
            StopEnemies();
        }
    }

    private void StopEnemies()
    {
        var activeEnemies = _enemyPool.GetActiveObjects();
        foreach (var enemy in activeEnemies)
        {
            enemy.Get<IStopable>().Stop();
        }
    }
    
    protected virtual void OnEnemyDead(Entity enemy)
    {   
        EnemyDied?.Invoke(_type);
        _enemyPool.ReturnObject(enemy);
        enemy.Get<IDamagable>().OnHealthEmpty -= OnEnemyDead;
    }
}

public enum EnemyType
{
    UFO,
    ASTEROID,
    FRAGMENT
}