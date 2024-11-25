using System;using Zenject;

public class LaserRechargeViewAdapter: IInitializable, IDisposable
{
    private LaserRechargeView _laserRechargeView;
    private PlayerWeapon _weapon;
    
    [Inject]
    private void Construct(LaserRechargeView laserRechargeView, Entity player)
    {
        _laserRechargeView = laserRechargeView;
        _weapon = player.Get<PlayerWeapon>();
    }
    
    public void Initialize()
    {
        _weapon.LaserIsRecharging += UpdateView;
    }

    public void Dispose()
    {
        _weapon.LaserIsRecharging -= UpdateView;
    }
    
    
    private void UpdateView(float value)
    {
        _laserRechargeView.UpdateText(value);
    }

    
}