using System;
using Zenject;

public class LaserShotViewAdapter: IInitializable, IDisposable
{
    private LaserShotView _laserShotView;
    private PlayerWeapon _weapon;
    
    [Inject]
    private void Construct(LaserShotView laserShotView, Entity player)
    {
        _laserShotView = laserShotView;
        _weapon = player.Get<PlayerWeapon>();
    }
    
    public void Initialize()
    {
        _weapon.NumberLaserShotsHasChanged += UpdateView;
    }

    public void Dispose()
    {
        _weapon.NumberLaserShotsHasChanged -= UpdateView;
    }
    
    private void UpdateView(int value)
    {
        _laserShotView.UpdateText(value);
    }

}