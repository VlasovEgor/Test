using UnityEngine;

public abstract class EnemySpawner: MonoBehaviour
{
    [SerializeField] private float _minTimeBetweenSpawns = 1;
    [SerializeField] private float _maxTimeBetweenSpawns = 2;

    protected IEnemySpawner _enemyManager;

    private bool _gameOnPause;
    private float _timeSinceLastSpawn;
    private float _nextSpawnTime;

    private void Start()
    {
        GameStateManager.Instance.GameStateChanged += OnGameStateChanged;
        _nextSpawnTime = Random.Range(_minTimeBetweenSpawns, _maxTimeBetweenSpawns);
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.GameStateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState state)
    {
        _gameOnPause = state == GameState.PAUSE;
    }

    private void Update()
    {
        if (_gameOnPause)
        {
            return;
        }

        _timeSinceLastSpawn += Time.deltaTime;

        if (_timeSinceLastSpawn >= _nextSpawnTime)
        {
            _enemyManager.SpawnEnemy();
            _timeSinceLastSpawn = 0;
            _nextSpawnTime = Random.Range(_minTimeBetweenSpawns, _maxTimeBetweenSpawns);
        }
    }
}