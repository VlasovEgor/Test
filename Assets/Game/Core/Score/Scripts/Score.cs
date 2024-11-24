using System;
using Zenject;

public class Score : IInitializable, IDisposable
{
    private UFOManager _ufoManager;
    private AsteroidManager _asteroidManager;
    private FragmentManager _fragmentManager;
    
    private ScoreConfig _scoreConfig;

    private int _score;
    
    [Inject]
    private void Construct(UFOManager ufoManager, 
        AsteroidManager asteroidManager, 
        FragmentManager fragmentManager, 
        ScoreConfig scoreConfig)
    {
        _ufoManager = ufoManager;
        _asteroidManager = asteroidManager;
        _fragmentManager = fragmentManager;
        
        _scoreConfig = scoreConfig;
    }
    
    public void Initialize()
    {
        _ufoManager.EnemyDied += AddScore;
        _asteroidManager.EnemyDied += AddScore;
        _ufoManager.EnemyDied += AddScore;
    }

    public void Dispose()
    {
        _ufoManager.EnemyDied -= AddScore;
        _asteroidManager.EnemyDied -= AddScore;
        _fragmentManager.EnemyDied -= AddScore;
    }

    private void AddScore(EnemyType type)
    {   
        _score += _scoreConfig.GetScoreByType(type);
    }

    public int GetScore()
    {
        return _score;
    }
}
