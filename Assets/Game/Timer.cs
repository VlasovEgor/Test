using System;
using UnityEngine;
using System.Collections;

public sealed class Timer : MonoBehaviour
{
    public event Action OnEnded;
    public event Action OnStarted;
    public event Action OnTimeChanged;

    public bool IsPlaying { get; private set; }

    public float Duration
    {
        get { return _duration; }
        set { _duration = value; }
    }

    public float RemainingTime => _remainingTime;

    [SerializeField] private float _duration;
    private float _currentTime;
    private float _remainingTime;

    public void Play()
    {
        if (!IsPlaying)
        {
            IsPlaying = true;
            OnStarted?.Invoke();
        }
    }

    public void Stop()
    {
        if (IsPlaying)
        {
            IsPlaying = false;
        }
    }

    public void ResetTime()
    {
        _currentTime = 0;
    }

    public float Progress
    {
        get { return _currentTime / _duration; }
    }

    private void Update()
    {
        if (IsPlaying)
        {
            _currentTime += Time.deltaTime;
            _remainingTime = _duration - _currentTime;
            OnTimeChanged?.Invoke();

            if (_currentTime >= _duration)
            {
                _currentTime = _duration;
                _remainingTime = 0;
                OnTimeChanged?.Invoke();
                IsPlaying = false;
                OnEnded?.Invoke();
            }
        }
    }
}

