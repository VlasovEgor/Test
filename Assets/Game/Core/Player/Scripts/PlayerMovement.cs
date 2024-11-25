using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 Position => _transform.position;
    public float Rotation => _transform.eulerAngles.z;
    public float InstantaneousSpeed => _rigidbody.velocity.magnitude;
    
    [SerializeField] private Transform _transform;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] protected float _speed = 5.0f;

    private LevelBounds _levelBounds;
    
    [Inject]
    private void Construct(LevelBounds levelBounds)
    {
        _levelBounds = levelBounds;
    }
    
    private void Update()
    {
        CheckLevelBounds();
    }

    private void CheckLevelBounds()
    {
        if (_levelBounds.InBounds(_transform.position) == false)
        {   
            _transform.position = _levelBounds.NewMirroredPosition(_transform.position);
        }
    }
    
    public void Move()
    {
        _rigidbody.AddForce(transform.up * _speed);
    }
}