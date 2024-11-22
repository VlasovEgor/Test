using UnityEngine;


public class BulletWeapon : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;

    private BulletManager _bulletManager;

    public void SetBulletManager(BulletManager bulletManager)
    {
        _bulletManager = bulletManager;
    }

    public void Attack()
    {
        Bullet bullet = _bulletManager.SpawnBullet(_firePoint.position);
        bullet.SetVelocity(GetDirectionShot());
    }
    
    private Vector3 GetDirectionShot()
    {
        return _firePoint.rotation * Vector3.up;
    }
}