using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public int CurrentLaserShots => _lazerWeapon.CurrentLaserShots;
    public float LaserRechargeTime => _lazerWeapon.LaserRechargeTime;
    
    [SerializeField] private BulletWeapon _bulletWeapon;
    [SerializeField] private LazerWeapon _lazerWeapon;

    [Space] [SerializeField] private int _maxLaserShots = 3;
    [SerializeField] private float _laserRechargeTime = 2.0f;

    public void SetBulletManager(BulletManager bulletManager)
    {
        _bulletWeapon.SetBulletManager(bulletManager);
    }

    public void BulletAttack()
    {
        _bulletWeapon.TryAttack();
    }

    public void LaserAttack()
    {
        _lazerWeapon.TryAttack();
    }
    
}
