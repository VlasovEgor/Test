using System;
using Zenject;

public sealed class PlayerController : IInitializable, IDisposable
{
    private BulletManager _bulletManager;
    private Entity _entity;
    private PlayerInput _input;

    [Inject]
    private void Construct(PlayerInput playerInput, Entity player, BulletManager bulletManager)
    {
        _input = playerInput;
        _entity = player;
        _bulletManager = bulletManager;
    }
    
    public void Initialize()
    {
        _input.Moved += OnPlayerMoved;
        _input.OnRotate += OnPlayerRotated;
        
        _input.OnFired += OnPlayerFired;
        
        _entity.Get<PlayerWeapon>().SetBulletManager(_bulletManager);
    }

    public void Dispose()
    {
        _input.Moved -= OnPlayerMoved;
        _input.OnRotate -= OnPlayerRotated;
        
        _input.OnFired -= OnPlayerFired;
    }
    

    private void OnPlayerMoved()
    {
        _entity.Get<PlayerMovement>().Move();
    }
    
    private void OnPlayerRotated(float inputValue)
    {
        _entity.Get<Rotation>().SetInputValue(inputValue);
    }

    private void OnPlayerFired()
    {
        _entity.Get<PlayerWeapon>().BulletAttack();
    }
}