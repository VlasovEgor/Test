using Zenject;

public class CoordinatesViewAdapter: ITickable
{
    private CoordinatesView _coordinatesView;
    private PlayerMovement _playerMovement;
    
    [Inject]
    private void Construct(CoordinatesView coordinatesView, Entity player)
    {
        _coordinatesView = coordinatesView;
        _playerMovement = player.Get<PlayerMovement>();
    }

    public void Tick()
    {
        UpdateView();
    }
    
    private void UpdateView()
    {
        _coordinatesView.UpdateText(_playerMovement.Position);
    }
}
