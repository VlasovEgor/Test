using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector2 Position => _rigidbody.position;

    [SerializeField] private Rigidbody2D _rigidbody;

    [SerializeField] protected float _speed = 5.0f;

    public void MoveToPosition(float input)
    {
        Vector2 localDirection = new Vector2(0f, input);
        Vector2 worldDirection = transform.TransformDirection(localDirection);
        
        _rigidbody.velocity = worldDirection * _speed;
    }

    public Vector2 GetMoveStep(Vector2 direction)
    {
        return direction.normalized * Time.fixedDeltaTime * _speed;
    }
}