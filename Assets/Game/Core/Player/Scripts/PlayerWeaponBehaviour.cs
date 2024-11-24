using UnityEngine;


public class PlayerWeaponBehaviour : MonoBehaviour
{
    public int CurrentLaserShots => _currentLaserShots;
    public float LaserRechargeTime => GetRemainingLaserRechargeTime();
    
    [SerializeField] private BulletWeapon _bulletWeapon;
    [SerializeField] private LazerWeapon _lazerWeapon;

    [Space] [SerializeField] private int _maxLaserShots = 3;
    [SerializeField] private float _laserRechargeTime = 2.0f;

    private int _currentLaserShots;
    private float _lastLaserShotTime;

    private void Start()
    {
        _currentLaserShots = _maxLaserShots;
        _lastLaserShotTime = Time.time;
    }

    private void Update()
    {
        RechargeLaserShots();
    }

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
        if (_currentLaserShots <= 0) return;

        if (_lazerWeapon.TryAttack())
        {
            _currentLaserShots--;
            _lastLaserShotTime = Time.time;
        }
    }

    private void RechargeLaserShots()
    {
        if (_currentLaserShots >= _maxLaserShots) return;

        float remainingTime = GetRemainingLaserRechargeTime();
        if (remainingTime <= 0)
        {
            _currentLaserShots++;
            _lastLaserShotTime += _laserRechargeTime;
        }
    }

    private float GetRemainingLaserRechargeTime()
    {
        if (_currentLaserShots >= _maxLaserShots) return 0f;
        
        float timeSinceLastShot = Time.time - _lastLaserShotTime;
        float remainingTime = _laserRechargeTime - timeSinceLastShot;

        return remainingTime > 0 ? remainingTime : 0f;

    }
}
