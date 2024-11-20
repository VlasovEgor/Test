using UnityEngine;


public class EnemyMovement : MonoBehaviour
{   
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] protected float _speed = 5.0f;
    
    private Vector2 _destination;
    private bool _isPointReached;

    private void FixedUpdate()
    {
        if (CheckAbilityMove())
        {
            Move();
        }
    }

    public void SetDestination(Vector2 destination)
    {
        _destination = destination;
        _isPointReached = false;
    }

    private bool CheckAbilityMove()
    {
        Vector2 vector = _destination - (Vector2)transform.position;

        if (vector.magnitude <= 0.25f)
        {
            _isPointReached = true;
            return false;
        }

        return true;
    }

    private void Move()
    {
        Vector2 vector = _destination - (Vector2)transform.position;

        Vector2 moveStep = GetMoveStep(vector);
        Vector2 nextPosition = (Vector2)transform.position + moveStep;
        MoveToPosition(nextPosition);
    }
    
    public void MoveToPosition(Vector2 nextPosition)
    {
       // _rigidbody.AddForce(transform.up * _speed);
    }

    public Vector2 GetMoveStep(Vector2 direction)
    {
        return direction.normalized * Time.fixedDeltaTime * _speed;
    }
}