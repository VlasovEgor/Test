using UnityEngine;
using Zenject;

public class GameContextInstaller : MonoInstaller
{   
    [SerializeField] private UFOManager _ufoManager;
    [SerializeField] private AsteroidManager _asteroidManager;
    [SerializeField] private FragmentManager _fragmentManager;
    [SerializeField] private BulletManager _bulletManager;
    
    [SerializeField] private ScoreConfig _scoreConfig;
    
    public override void InstallBindings()
    {
        BindGameOverController();
        BindPlayerInput();
        BindPlayerController();
        BindLevelBounds();
        
        BindUfoManager();
        BindAsteroidManager();
        BindFragmentManager();
        BindBulletManager();

        BindScore();
        BindScoreConfig();
    }

    private void BindGameOverController()
    {
        Container.BindInterfacesAndSelfTo<GameStateController>().AsSingle();
    }
    
    private void BindPlayerInput()
    {
        Container.BindInterfacesAndSelfTo<PlayerInput>().AsSingle();
    }
    
    private void BindPlayerController()
    {
        Container.BindInterfacesAndSelfTo<PlayerController>().AsSingle();
    }
    
    private void BindLevelBounds()
    {
        Container.BindInterfacesAndSelfTo<LevelBounds>().AsSingle();
    }
    
    private void BindUfoManager()
    {
        Container.Bind<UFOManager>().FromInstance(_ufoManager).AsSingle();
    }
    
    private void BindAsteroidManager()
    {
        Container.Bind<AsteroidManager>().FromInstance(_asteroidManager).AsSingle();
    }
    
    private void BindFragmentManager()
    {
        Container.Bind<FragmentManager>().FromInstance(_fragmentManager).AsSingle();
    }
    
    private void BindBulletManager()
    {
        Container.BindInterfacesAndSelfTo<BulletManager>().FromInstance(_bulletManager).AsSingle();
    }
    
    private void BindScore()
    {
        Container.BindInterfacesAndSelfTo<Score>().AsSingle();
    }
    
    private void BindScoreConfig()
    {
        Container.BindInterfacesAndSelfTo<ScoreConfig>().FromInstance(_scoreConfig).AsSingle();
    }
}
