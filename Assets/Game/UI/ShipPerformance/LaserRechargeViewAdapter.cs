using Zenject;

public class LaserRechargeViewAdapter: ITickable
{
    private LaserRechargeView _laserRechargeView;
    private PlayerWeaponBehaviour _weaponBehaviour;
    
    [Inject]
    private void Construct(LaserRechargeView laserRechargeView, Entity player)
    {
        _laserRechargeView = laserRechargeView;
        _weaponBehaviour = player.Get<PlayerWeaponBehaviour>();
    }

    public void Tick()
    {
        UpdateView();
    }
    
    private void UpdateView()
    {
        _laserRechargeView.UpdateText(_weaponBehaviour.LaserRechargeTime);
    }
}