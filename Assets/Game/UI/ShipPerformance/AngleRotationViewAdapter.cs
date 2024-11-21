using Zenject;

public class AngleRotationViewAdapter: ITickable
{
    private AngleRotationView _angleRotationView;
    private PlayerMovement _playerMovement;
    
    [Inject]
    private void Construct(AngleRotationView angleRotationView, Entity player)
    {
        _angleRotationView = angleRotationView;
        _playerMovement = player.Get<PlayerMovement>();
    }
    
    public void Tick()
    {
        UpdateView();
    }
    
    private void UpdateView()
    {
        _angleRotationView.UpdateText(_playerMovement.Rotation);
    }
}
