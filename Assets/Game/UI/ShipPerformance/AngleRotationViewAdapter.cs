using System;using Zenject;

public class AngleRotationViewAdapter: IInitializable, IDisposable
{
    private AngleRotationView _angleRotationView;
    private Rotation _playerRotation;
    
    [Inject]
    private void Construct(AngleRotationView angleRotationView, Entity player)
    {
        _angleRotationView = angleRotationView;
        _playerRotation = player.Get<Rotation>();
    }
    
    public void Initialize()
    {
        _playerRotation.RotationChanged += UpdateView;
    }

    public void Dispose()
    {
        _playerRotation.RotationChanged -= UpdateView;
    }
    
    private void UpdateView(float value)
    {
        _angleRotationView.UpdateText(value);
    }
}