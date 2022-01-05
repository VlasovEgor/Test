using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneNew : MonoBehaviour
{
    [SerializeField] private PlayerNew _player;
    [SerializeField] private float _distanceToDeath;
    [SerializeField] private Animator _animator;
    [SerializeField] private bool animation = true;
    private void Start()
    {
        _player = FindObjectOfType<PlayerNew>();
        _animator = _player.GetComponent<Animator>();

    }
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, _player.transform.position);
        if (distance < _distanceToDeath && _player.Immortality == false)
        {
            if (animation == true)
            {
                _animator.SetTrigger("Death");
                animation = false;
            }

        }
        if (animation == false & distance > 3)
        {
            animation = true;
        }
    }
}
