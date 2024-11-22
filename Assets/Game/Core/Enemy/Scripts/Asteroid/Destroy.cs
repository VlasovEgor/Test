using System;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour, IDamagable
{
    public event Action<Entity> OnHealthEmpty;

    [SerializeField] private Entity _entity;
    [SerializeField] private int _maxHealth;

    [SerializeField] private List<Entity> _chips;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            return;
        }

        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnHealthEmpty?.Invoke(_entity);
        TurningOnChips();
    }

    private void TurningOnChips()
    {
        foreach (var chip in _chips)
        {
            chip.SetActive(true);
        }
    }
}
