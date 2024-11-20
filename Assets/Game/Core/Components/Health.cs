using System;
using UnityEngine;


public class Health : MonoBehaviour
{
    public event Action<Entity> OnHealthEmpty;

    [SerializeField] private Entity _entity;
    [SerializeField] private int _maxHealth;

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
    }
}