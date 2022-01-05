using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryNew : MonoBehaviour
{
    [SerializeField] private PlayerNew _player;
    [SerializeField] private ParticleSystem _particals;
    [SerializeField] private CreatingBarriers _creatingBarriers;
    [SerializeField] private Animator _animator;
    private void Start()
    {
        _player = FindObjectOfType<PlayerNew>();

    }
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, _player.transform.position);

        if (distance < 1)
        {
            
            _player.transform.position = _player.SpawnPosition;
            _player.NavMeshAgent.enabled = false;
            Invoke("ReturnToStart", 2.5f);
            _particals.Play();
            _animator.SetTrigger("SceneChange");
        }

    }
    public void SceneChange()
    {

        _creatingBarriers.ClearingMap();
        _creatingBarriers.CreatBarriersAndDeadZone();
        _animator.SetTrigger("SceneChange");
    }

    void ReturnToStart()
    {
        _player.Dead();
    }
}
