using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNew : MonoBehaviour
{
    [SerializeField] private GameObject _vicroryZone;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _invulnerabilityColor;
    [SerializeField] private Material material;

    public bool Immortality;
    public Vector3 SpawnPosition;
    public NavMeshAgent NavMeshAgent;

    bool reboot = true;

    private void Start()
    {
        material.color = _startColor;
        Invoke("MoveToVictoryZone", 2f);
    }

    private void MoveToVictoryZone()
    {

        NavMeshAgent.SetDestination(_vicroryZone.transform.position);
    }

    public void Dead()
    {
        transform.position = SpawnPosition;
        NavMeshAgent.enabled = false;
        Invoke("MotionReturn", 2f);
    }
    void MotionReturn()
    {

        NavMeshAgent.enabled = true;
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

