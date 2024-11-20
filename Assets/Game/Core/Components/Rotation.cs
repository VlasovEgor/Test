using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _transform;

    private float _currentInputValue;

    public void SetInputValue(float value)
    {
        _currentInputValue = value;
        OnRotating();
    }
    
    private void OnRotating()
    {
        if (_currentInputValue == 0) return;

       // Quaternion targetRotation = Quaternion.LookRotation(_currentDirection, Vector3.up);
       // 
       // _transform.rotation = Quaternion.RotateTowards(
       //     _transform.rotation,
       //     targetRotation,
       //     _speed * Time.deltaTime
       // );
       
       float rotationStep = -1* _currentInputValue * _speed * Time.deltaTime;

       // Применяем вращение только по оси Z
       _transform.Rotate(0f, 0f, rotationStep);
    }
    
}
