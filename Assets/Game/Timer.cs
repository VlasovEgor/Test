using System;
using UnityEngine;

public sealed class Timer : MonoBehaviour
{
    public event Action OnEnded;
    
    [SerializeField] private float _duration;
    
    private float _currentTime;
    private bool _isPlaying;

    public void Play()
    {
        if (!_isPlaying)
        {
            _isPlaying = true;
        }
    }

    public void Stop()
    {
        if (_isPlaying)
        {
            _isPlaying = false;
        }
    }

    public void ResetTime()
    {
        _currentTime = 0;
    }
    
    private void Update()
    {
        if (!_isPlaying) return;
        
        _currentTime += Time.deltaTime;

        if (_currentTime >= _duration)
        {
            _currentTime = _duration;
            _isPlaying = false;
            OnEnded?.Invoke();
        }
    }
}

