using UnityEngine;
using Zenject;


public class PlayerMovementBehaviour : MonoBehaviour
{
    [SerializeField] private Movement _movement;

    private LevelBounds _levelBounds;
    private float _currentInputValue;
    
    [Inject]
    private void Construct(LevelBounds levelBounds)
    {
        _levelBounds = levelBounds;
    }
    
    public void SetInputValue(float value)
    {
        _currentInputValue = value;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
       // Vector2 moveStep = _movement.GetMoveStep(_currentDirection);
       // Vector2 nextPosition = _movement.Position + moveStep;
//
       // if (_levelBounds.InBounds(nextPosition))
       // {
       //     _movement.MoveToPosition(nextPosition);
       // }
       // else
       // {
       //     _movement.MoveToPosition(_movement.Position);
       // }
       
       _movement.MoveToPosition(_currentInputValue);
    }
}