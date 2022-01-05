using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _distanceToDeath;
    private void Start()
    {
        _player = FindObjectOfType<Player>();

    }
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, _player.transform.position);
        if(distance< _distanceToDeath&& _player.Immortality==false)
        {
            _player.Dead();
        }
        
    }
}
