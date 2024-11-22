using UnityEngine;
using UnityEngine.Serialization;


public class PlayerWeaponBehaviour : MonoBehaviour
{
    [SerializeField] private BulletWeapon _bulletWeapon;
    [SerializeField] private LazerWeapon _lazerWeapon;
    
    public void SetBulletManager(BulletManager bulletManager)
    {
        _bulletWeapon.SetBulletManager(bulletManager);
    }

    public void Attack()
    {
       // _bulletWeapon.Attack(GetDirectionShot());
       _lazerWeapon.Attack();
    }

    
}