using System;
using UnityEngine;

public class ColliderProxy : MonoBehaviour
{
    public event Action<Collision2D> OnCollisionEntered;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        OnCollisionEntered?.Invoke(other);
    }
}
