using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
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
            _transform.position = _levelBounds.NewPosition(_transform.position);
        }
    }
    
    public void Move()
    {
        _rigidbody.AddForce(transform.up * _speed);
    }
}