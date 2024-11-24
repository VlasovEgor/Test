using UnityEngine;


public class UFOSpawner : EnemySpawner
{
    [SerializeField] private UFOManager _ufoManager;

    private void Awake()
    {
        _enemyManager = _ufoManager;
    }
}