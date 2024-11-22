using UnityEngine;

[CreateAssetMenu(fileName = "ScoreConfig", menuName = "Configs/ScoreConfig")]
public class ScoreConfig : ScriptableObject
{
   public int UFOScore => _ufoScore;
   public int AsteroidScore => _asteroidScore;
   public int ChipScore => _chipScore;

   [SerializeField] private int _ufoScore;
   [SerializeField] private int _asteroidScore;
   [SerializeField] private int _chipScore;
}
