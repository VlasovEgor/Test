using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreConfig", menuName = "Configs/ScoreConfig")]
public class ScoreConfig : ScriptableObject
{  
   [SerializeField] private List<ScoreData> _enemiesScore = new ();

   public int GetScoreByType(EnemyType enemyType)
   {
      return _enemiesScore
         .Where(scoreData => scoreData.Type == enemyType)
         .Select(scoreData => scoreData.Score)
         .FirstOrDefault();
   }
}

[Serializable]
public struct ScoreData
{
   public EnemyType Type;
   public int Score;
}
