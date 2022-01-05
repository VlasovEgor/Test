using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _vicroryZone;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Vector3 _spawnPosition;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _invulnerabilityColor;
    [SerializeField] private Material material;

    public bool Immortality;
    bool reboot= true;
    private void Start()
    {
        material.color = _startColor;
        Invoke("MoveToVictoryZone", 2f);
    }

    private void MoveToVictoryZone()
    {

        _navMeshAgent.SetDestination(_vicroryZone.transform.position);
    }

    public void Dead()
    {

        transform.position = _spawnPosition;
        _navMeshAgent.enabled = false;
        Invoke("MotionReturn", 2f);
    }
    void MotionReturn()
    {
        _navMeshAgent.enabled = true;
        MoveToVictoryZone();

    }

    public void Invulnerability()
    {   
        if (reboot)
        {
            material.color = _invulnerabilityColor;
            Immortality = true;
            Invoke("Vulnerability", 2f);
        }

    }

    public void Vulnerability()
    {
        material.color = _startColor;
        Immortality = false;
        reboot = false;
        Invoke("RebootInvulnerability", 0.5f);
    }

    void RebootInvulnerability()
    {
        reboot = true;
    }
}
