using System;
using UnityEngine;
using Zenject;

public class GameOverController : IInitializable, IDisposable
{
    public event Action GameOver;
    private Entity _player;
    
    [Inject]
    private void Construct(Entity player)
    {
        _player = player;
    }
    
    public void Initialize()
    {
        _player.Get<Health>().OnHealthEmpty += PlayerDead;
    }

    public void Dispose()
    {
        _player.Get<Health>().OnHealthEmpty -= PlayerDead;
    }

    private void PlayerDead(Entity player)
    {
        player.SetActive(false);
        StopGame();
    }

    private void StopGame()
    {   
        GameOver?.Invoke();
        Time.timeScale = 0;
    }
}