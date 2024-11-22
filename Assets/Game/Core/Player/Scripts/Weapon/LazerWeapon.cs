using System.Collections;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LazerWeapon : MonoBehaviour
{
   [SerializeField] private Transform _firePoint;
   [SerializeField] private float _laserRange = 5f;
   [SerializeField] private float extendDuration = 1f;
   
   private LineRenderer _line;

   private void Start()
   {
      _line = GetComponent<LineRenderer>();
      _line.enabled = false;
   }

   public void Attack()
   {  
      StartCoroutine(ExtendLaser());
   }
   
   IEnumerator ExtendLaser()
   {
      _line.enabled = true;
      float elapsedTime = 0f;

      while (elapsedTime < extendDuration)
      {
         float currentRange = Mathf.Lerp(0, _laserRange, elapsedTime / extendDuration);
         _line.SetPosition(0, _firePoint.position);
         _line.SetPosition(1, _firePoint.position + _firePoint.up * currentRange);

         RaycastHit2D[] hits = Physics2D.RaycastAll(_firePoint.position, _firePoint.up, currentRange);
         foreach (RaycastHit2D hit in hits)
         {
           Debug.Log("ABOBA");
         }

         elapsedTime += Time.deltaTime;
         yield return null;
      }
      
      _line.enabled = false;
   }
}
