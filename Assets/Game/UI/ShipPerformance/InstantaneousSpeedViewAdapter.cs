using Zenject;

public class InstantaneousSpeedViewAdapter: ITickable
{
    private InstantaneousSpeedView _instantaneousSpeedView;
    private PlayerMovement _playerMovement;

    [Inject]
    private void Construct(InstantaneousSpeedView instantaneousSpeedView, Entity player)
    {
        _instantaneousSpeedView = instantaneousSpeedView;
        _playerMovement = player.Get<PlayerMovement>();
    }
    
    public void Tick()
    {
        UpdateView();
    }

    private void UpdateView()
    {
        _instantaneousSpeedView.UpdateText(_playerMovement.InstantaneousSpeedView);
    }
}
