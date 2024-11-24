using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidMovement : MonoBehaviour, IStopable
{
    [SerializeField] private Transform _transform;
    [SerializeField] protected float _speed = 5.0f;

    private Vector3 _direction;

    private void OnEnable()
    {
        ChoosingDirection();
    }

    private void Update()
    {
        Move();
    }

    private void ChoosingDirection()
    {
        _direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    public void Stop()
    {
        _speed = 0;
    }
    
    private void Move()
    {
        var moveStep = _direction * _speed * Time.deltaTime;

        _transform.position += moveStep;
    }
}
