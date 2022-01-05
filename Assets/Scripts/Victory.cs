using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private ParticleSystem _particals;
    [SerializeField] private CreatingBarriers _creatingBarriers;
    private void Start()
    {
        _player = FindObjectOfType<Player>();

    }
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, _player.transform.position);
        if (distance < 1)
        {
            _particals.Play();
            _player.Dead();
           _creatingBarriers.ClearingMap();
           _creatingBarriers.CreatBarriersAndDeadZone();
            
        }

    }
}
