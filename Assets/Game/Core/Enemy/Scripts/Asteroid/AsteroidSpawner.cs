using UnityEngine;

public class AsteroidSpawner: EnemySpawner
{
    [SerializeField] private AsteroidManager _asteroidManager;

    private void Awake()
    {
        _enemyManager = _asteroidManager;
    }
}