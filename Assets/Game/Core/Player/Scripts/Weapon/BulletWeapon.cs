using System.Collections;
using UnityEngine;

public class BulletWeapon : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _fireRate = 1.0f;

    private BulletManager _bulletManager;
    private bool _canFire = true;

    public void SetBulletManager(BulletManager bulletManager)
    {
        _bulletManager = bulletManager;
    }

    public void TryAttack()
    {
        if (!_canFire) return;
        
        Attack();
    }

    private void Attack()
    {
        Bullet bullet = _bulletManager.SpawnBullet();
        
        bullet.SetPosition(_firePoint.position);
        bullet.SetVelocity(_firePoint.rotation * Vector3.up);
        
        StartCoroutine(FireRateTimer());
    }

    private IEnumerator FireRateTimer()
    {
        _canFire = false;
        yield return new WaitForSeconds(_fireRate);
        _canFire = true;
    }
}