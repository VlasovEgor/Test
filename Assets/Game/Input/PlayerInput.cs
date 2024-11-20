using System;
using UnityEngine;
using Zenject;

public class PlayerInput : ITickable
{
    public event Action OnFired;
    public event Action Moved;
    public event Action<float> OnRotate;
    
    public void Tick()
    {
        Movement();
        Rotation();
        Fire();
    }

    private void Movement()
    {
        float move = Input.GetAxis("Vertical");

        if (move <= 0)
        {
            return;
        }
        
        Moved?.Invoke();
    }

    private void Rotation()
    {
        float rotate = Input.GetAxis("Horizontal");
        
        OnRotate?.Invoke(rotate);
    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnFired?.Invoke();
        }
    }
}