using System;
using UnityEngine;
using Zenject;

public class GameOverController : IInitializable, IDisposable
{
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
        Time.timeScale = 0;
    }
}