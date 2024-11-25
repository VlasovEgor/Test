using System;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{   
    public event Action<float> LaserIsRecharging;
    
    public event Action<int> NumberLaserShotsHasChanged;
    
    
    [SerializeField] private BulletWeapon _bulletWeapon;
    [SerializeField] private LazerWeapon _lazerWeapon;

    private void Start()
    {
        _lazerWeapon.LaserIsRecharging += LaserIsRecharging;
        _lazerWeapon.NumberShotsHasChanged += NumberLaserShotsHasChanged;
    }

    private void OnDestroy()
    {
        _lazerWeapon.LaserIsRecharging -= LaserIsRecharging;
        _lazerWeapon.NumberShotsHasChanged -= NumberLaserShotsHasChanged;
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
