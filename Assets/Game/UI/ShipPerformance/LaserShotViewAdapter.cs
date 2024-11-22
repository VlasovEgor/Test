﻿using Zenject;

public class LaserShotViewAdapter: ITickable
{
    private LaserShotView _laserShotView;
    private PlayerWeapon _weapon;
    
    [Inject]
    private void Construct(LaserShotView laserShotView, Entity player)
    {
        _laserShotView = laserShotView;
        _weapon = player.Get<PlayerWeapon>();
    }

    public void Tick()
    {
        UpdateView();
    }
    
    private void UpdateView()
    {
        _laserShotView.UpdateText(_weapon.CurrentLaserShots);
    }
}