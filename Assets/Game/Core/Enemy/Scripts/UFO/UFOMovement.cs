using UnityEngine;

public class UFOMovement : MonoBehaviour, IStopable
{   
    [SerializeField] private Transform _transform;
    [SerializeField] protected float _speed = 5.0f;
    
    private Vector2 _destination;
    private bool _isPointReached;
    private Transform _targetTransform;

    private void Update()
    {
        if (_targetTransform != null)
        {
            Move();
        }
    }

    public void SetTarget(Transform target)
    {
        _targetTransform = target;
    }

    public void Stop()
    {
        _speed = 0;
    }
    
    private void Move()
    {
        var vector = _targetTransform.position - transform.position;
        var direction = vector.normalized;
        
        var moveStep = direction * _speed * Time.deltaTime;
        
        _transform.Translate(moveStep);
    }
}