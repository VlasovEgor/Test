using Zenject;

public class LaserRechargeViewAdapter: ITickable
{
    private LaserRechargeView _laserRechargeView;
    private PlayerWeapon _weapon;
    
    [Inject]
    private void Construct(LaserRechargeView laserRechargeView, Entity player)
    {
        _laserRechargeView = laserRechargeView;
        _weapon = player.Get<PlayerWeapon>();
    }

    public void Tick()
    {
        UpdateView();
    }
    
    private void UpdateView()
    {
        _laserRechargeView.UpdateText(_weapon.LaserRechargeTime);
    }
}