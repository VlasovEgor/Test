using System;
using UnityEngine;
using Zenject;

public class PlayerInput : IInitializable, IDisposable, ITickable
{
    public event Action BulletFired;
    
    public event Action LaserFired;
    
    public event Action Moved;
    
    public event Action<float> Rotated;
    
    private bool _gameOnPause;

    public void Initialize()
    {
        GameStateManager.Instance.GameStateChanged += OnGameStateChanged;
    }

    public void Dispose()
    {
        GameStateManager.Instance.GameStateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState state)
    {
        _gameOnPause = state == GameState.PAUSE;
    }
    
    public void Tick()
    {
        if (_gameOnPause)
        {
            return;
        }
        
        Movement();
        Rotation();
        Fire();
    }

    private void Movement()
    {
        float move = Input.GetAxis("Vertical");

        if (move <= 0)
        {
            return;
        }
        
        Moved?.Invoke();
    }

    private void Rotation()
    {
        float rotate = Input.GetAxis("Horizontal");
        
        Rotated?.Invoke(rotate);
    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BulletFired?.Invoke();
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            LaserFired?.Invoke();
        }
    }
}