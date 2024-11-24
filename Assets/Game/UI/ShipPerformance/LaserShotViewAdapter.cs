using Zenject;

public class LaserShotViewAdapter: ITickable
{
    private LaserShotView _laserShotView;
    private PlayerWeaponBehaviour _weaponBehaviour;
    
    [Inject]
    private void Construct(LaserShotView laserShotView, Entity player)
    {
        _laserShotView = laserShotView;
        _weaponBehaviour = player.Get<PlayerWeaponBehaviour>();
    }

    public void Tick()
    {
        UpdateView();
    }
    
    private void UpdateView()
    {
        _laserShotView.UpdateText(_weaponBehaviour.CurrentLaserShots);
    }
}