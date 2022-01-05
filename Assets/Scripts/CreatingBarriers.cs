using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreatingBarriers : MonoBehaviour
{
    [SerializeField] private GameObject _barrier;
    [SerializeField] private GameObject _deadZone;
    [SerializeField] private List<GameObject> _barrierList = new List<GameObject>();
    [SerializeField] private List<GameObject> _deadZoneList = new List<GameObject>();
    [SerializeField] private Vector3 _spawnValue;
    [SerializeField] private int _numberWalls;
    [SerializeField] private int _numberZone;
    [SerializeField] private int _maxDistanceBarrier = 1;
    [SerializeField] private int _minDistanceBarrier = 10;
    [SerializeField] private ParticleSystem _particals;
    private void Start()
    {
        CreatBarriersAndDeadZone();
        _particals.Stop();
    }
    int TurnRandom()
    {
        int[] arr = new int[2] { 90, 180 };
        int rand = Random.Range(0, 2);
        return arr[rand];
    }
    public void CreatBarriersAndDeadZone()
    {
        Vector3 spawnPosition;
        for (int i = 0; i < _numberWalls; i++)
        {
            spawnPosition = new Vector3(Random.Range(-_spawnValue.x, _spawnValue.x), 1, Random.Range(-_spawnValue.z, _spawnValue.z));
            while (spawnPosition.x < -17 && spawnPosition.z < -17 || spawnPosition.x > 17 && spawnPosition.z > 17)
            {
                spawnPosition = new Vector3(Random.Range(-_spawnValue.x, _spawnValue.x), 1, Random.Range(-_spawnValue.z, _spawnValue.z));
            }
            int turnRandom = TurnRandom();
            Quaternion spawnRotation = Quaternion.Euler(0, turnRandom, 0);
            GameObject newBarrier = Instantiate(_barrier, spawnPosition, spawnRotation);
            newBarrier.transform.localScale = new Vector3(Random.Range(_minDistanceBarrier, _maxDistanceBarrier), 3, 2);
            _barrierList.Add(newBarrier);

        }
        for (int i = 0; i < _numberZone; i++)
        {
            spawnPosition = new Vector3(Random.Range(-_spawnValue.x, _spawnValue.x), 0.01f, Random.Range(-_spawnValue.z, _spawnValue.z));
            while (spawnPosition.x < -17 && spawnPosition.z < -17 || spawnPosition.x > 17 && spawnPosition.z > 17)
            {
                spawnPosition = new Vector3(Random.Range(-_spawnValue.x, _spawnValue.x), 0.01f, Random.Range(-_spawnValue.z, _spawnValue.z));
            }
            GameObject newDeadZone = Instantiate(_deadZone, spawnPosition, Quaternion.identity);
            _deadZoneList.Add(newDeadZone);
        }
    }
    
    public void ClearingMap()
    {
        while (_barrierList.Count > 0)
        {
            ClearBarrier(_barrierList[0]);

        }
        while (_deadZoneList.Count > 0)
        {

            ClearDeadZone(_deadZoneList[0]);
        }
    }
    public void ClearBarrier(GameObject _barrier)
    {
        _barrierList.Remove(_barrier);
        Destroy(_barrier);
    }
    public void ClearDeadZone(GameObject _deadZone)
    {
        _deadZoneList.Remove(_deadZone);
        Destroy(_deadZone);
    }
}
