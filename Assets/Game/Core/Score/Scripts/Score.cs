using System;
using Zenject;

public class Score : IInitializable, IDisposable
{
    private UFOManager _ufoManager;
    private ScoreConfig _scoreConfig;

    private int _score;
    
    [Inject]
    private void Construct(UFOManager ufoManager, ScoreConfig scoreConfig)
    {
        _ufoManager = ufoManager;
        _scoreConfig = scoreConfig;
    }
    
    public void Initialize()
    {
        _ufoManager.UFODead += AddUfoScore;
    }

    public void Dispose()
    {
        _ufoManager.UFODead -= AddUfoScore;
    }

    private void AddUfoScore()
    {
        _score += _scoreConfig.UFOScore;
    }

    public int GetScore()
    {
        return _score;
    }
}
