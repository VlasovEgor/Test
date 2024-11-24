using System.Collections;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LazerWeapon : MonoBehaviour
{  
   public int CurrentLaserShots => _currentLaserShots;
   public float LaserRechargeTime => GetRemainingLaserRechargeTime();
   
   [SerializeField] private Transform _firePoint;
   [SerializeField] private LayerMask _enemyLayerMask;
   [Space]
   [SerializeField] private int _damage = 1;
   [SerializeField] private float _laserRange = 5f;
   [SerializeField] private float _extendDuration = 1f;
   [SerializeField] private int _maxLaserShots = 3;
   [SerializeField] private float _laserRechargeTime = 2.0f;
   
   
   private LineRenderer _line;
   private bool _canFire = true;
   private int _currentLaserShots;
   private float _lastLaserShotTime;

   private void Start()
   {
      _line = GetComponent<LineRenderer>();
      _line.enabled = false;
      
      _currentLaserShots = _maxLaserShots;
      _lastLaserShotTime = Time.time;
   }

   private void Update()
   {
      RechargeLaserShots();
   }

   public void TryAttack()
   {  
      if (!_canFire || _currentLaserShots <= 0) return;
      
      StartCoroutine(ExtendLaser());
      StartCoroutine(FireRateTimer());
      
      _currentLaserShots--;
      _lastLaserShotTime = Time.time;
   }
   
   private IEnumerator ExtendLaser()
   {
      _line.enabled = true;
      float elapsedTime = 0f;

      while (elapsedTime < _extendDuration)
      {
         float currentRange = Mathf.Lerp(0, _laserRange, elapsedTime / _extendDuration);
         _line.SetPosition(0, _firePoint.position);
         _line.SetPosition(1, _firePoint.position + _firePoint.up * currentRange);

         RaycastHit2D[] hits = Physics2D.RaycastAll(
            _firePoint.position, 
            _firePoint.up, 
            currentRange,
            _enemyLayerMask);
         
         foreach (RaycastHit2D hit in hits)
         {
            if (hit.collider.TryGetComponent<Entity>(out var entity))
            {
               if (entity.TryGet<IDamagable>(out var damagable))
               {
                  damagable.TakeDamage(_damage);
               }
            }
         }

         elapsedTime += Time.deltaTime;
         yield return null;
      }
      
      _line.enabled = false;
   }
   
   private IEnumerator FireRateTimer()
   {
      _canFire = false;
      yield return new WaitForSeconds(_extendDuration);
      _canFire = true;
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