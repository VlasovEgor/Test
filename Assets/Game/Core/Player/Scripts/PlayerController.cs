using System;
using Zenject;

public sealed class PlayerController : IInitializable, IDisposable
{
    private Entity _entity;
    private PlayerInput _input;

    [Inject]
    private void Construct(PlayerInput playerInput, Entity player)
    {
        _input = playerInput;
        _entity = player;
    }
    
    public void Initialize()
    {
        _input.Moved += OnPlayerMoved;
        _input.Rotated += OnPlayerRotated;
        
        _input.BulletFired += BulletPlayerFired;
        _input.LaserFired += OnLaserFired;
    }

    public void Dispose()
    {
        _input.Moved -= OnPlayerMoved;
        _input.Rotated -= OnPlayerRotated;
        
        _input.BulletFired -= BulletPlayerFired;
        _input.LaserFired -= OnLaserFired;
    }
    

    private void OnPlayerMoved()
    {
        _entity.Get<PlayerMovement>().Move();
    }
    
    private void OnPlayerRotated(float inputValue)
    {
        _entity.Get<Rotation>().SetInputValue(inputValue);
    }

    private void BulletPlayerFired()
    {
        _entity.Get<PlayerWeapon>().BulletAttack();
    }
    
    private void OnLaserFired()
    {
        _entity.Get<PlayerWeapon>().LaserAttack();
    }
}