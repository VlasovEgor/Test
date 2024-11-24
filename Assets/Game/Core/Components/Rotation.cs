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
       
       float rotationStep = -1* _currentInputValue * _speed * Time.deltaTime;
       
       _transform.Rotate(0f, 0f, rotationStep);
    }
    
}
