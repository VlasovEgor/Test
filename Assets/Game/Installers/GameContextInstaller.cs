using UnityEngine;
using Zenject;

public class GameContextInstaller : MonoInstaller
{ 
    [SerializeField] private BulletManager _bulletManager;
    
    public override void InstallBindings()
    {
        BindGameOverController();
        BindPlayerInput();
        BindPlayerController();
        BindLevelBounds();
        BindBulletManager();
    }

    private void BindGameOverController()
    {
        Container.BindInterfacesAndSelfTo<GameOverController>().AsSingle();
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
    
    private void BindBulletManager()
    {
        Container.BindInterfacesAndSelfTo<BulletManager>().FromInstance(_bulletManager).AsSingle();
    }
}
