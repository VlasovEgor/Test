using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] protected float _speed = 5.0f;

    private Vector3 _direction;
    
    private void Update()
    {
        Move();
    }

    public void ChoosingDirection()
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
