using System.Collections.Generic;
using UnityEngine;


public sealed class Entity : MonoBehaviour
{
    [SerializeField] private List<MonoBehaviour> _components;

    public T Get<T>() where T : class
    {
        foreach (var component in _components)
        {
            if (component is T)
            {
                return component as T;
            }
        }

        return null;
    }
    
    public bool TryGet<T>(out T component) where T : class
    {
        component = null;
        foreach (var comp in _components)
        {
            if (comp is T)
            {
                component = comp as T;
                return true;
            }
        }

        return false;
    }

    public void SetActive(bool IsActive)
    {
        gameObject.SetActive(IsActive);
    }
}