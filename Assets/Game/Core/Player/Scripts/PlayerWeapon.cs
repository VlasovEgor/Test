using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public int CurrentLaserShots => _lazerWeapon.CurrentLaserShots;
    public float LaserRechargeTime => _lazerWeapon.LaserRechargeTime;
    
    [SerializeField] private BulletWeapon _bulletWeapon;
    [SerializeField] private LazerWeapon _lazerWeapon;

    public void BulletAttack()
    {
        _bulletWeapon.TryAttack();
    }

    public void LaserAttack()
    {
        _lazerWeapon.TryAttack();
    }
    
}
