using UnityEngine;
using Zenject;

public sealed class LevelBounds: IInitializable
{
    private Bounds _bounds;
    
    public void Initialize()
    {
        var bottomLeftCorner = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0, Camera.main.nearClipPlane));

        var topRightCorner = Camera.main.ViewportToWorldPoint(
            new Vector3(1, 1, Camera.main.nearClipPlane));

        Vector3 center = (bottomLeftCorner + topRightCorner) / 2;
        Vector3 size = topRightCorner - bottomLeftCorner;

        _bounds = new Bounds(center, size);
    }
    
    public bool InBounds(Vector3 position)
    {
        return _bounds.Contains(position);
    }

    public Vector3 NewPosition(Vector3 position)
    {
        Vector3 newPosition = position;
        
        newPosition.x = Wrap(newPosition.x, _bounds.min.x, _bounds.max.x);
        newPosition.y = Wrap(newPosition.y, _bounds.min.y, _bounds.max.y);

        return newPosition;
    }
    
    private float Wrap(float value, float min, float max)
    {
        float range = max - min;
        return min + (value - min + range) % range;
    }
    
    public Vector3 GetRandomPointOnBounds()
    {
        int side = Random.Range(0, 4);

        switch (side)
        {
            case 0: // Верхняя граница
                return new Vector3(
                    Random.Range(_bounds.min.x, _bounds.max.x), 
                    _bounds.max.y,                             
                    0);                                        

            case 1: // Нижняя граница
                return new Vector3(
                    Random.Range(_bounds.min.x, _bounds.max.x),
                    _bounds.min.y,                              
                    0);

            case 2: // Левая граница
                return new Vector3(
                    _bounds.min.x,                             
                    Random.Range(_bounds.min.y, _bounds.max.y),
                    0);

            case 3: // Правая граница
                return new Vector3(
                    _bounds.max.x,                              
                    Random.Range(_bounds.min.y, _bounds.max.y),
                    0);

            default:
                return Vector3.zero;
        }
    }

}