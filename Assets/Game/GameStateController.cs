using System;
using UnityEngine.SceneManagement;
using Zenject;

public class GameStateController : IInitializable, IDisposable
{
    public event Action GameStopped;
    private Entity _player;
    
    [Inject]
    private void Construct(Entity player)
    {
        _player = player;
    }
    
    public void Initialize()
    {
        _player.Get<IDamagable>().OnHealthEmpty += PlayerDead;
    }

    public void Dispose()
    {
        _player.Get<IDamagable>().OnHealthEmpty -= PlayerDead;
    }

    private void PlayerDead(Entity player)
    {
        StopGame();
    }

    private void StopGame()
    {   
        GameStopped?.Invoke();
        GameStateManager.Instance.SetState(GameState.PAUSE);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameStateManager.Instance.SetState(GameState.START);
    }
}