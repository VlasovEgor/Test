using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{   
    [SerializeField] private AngleRotationView _angleRotationView;
    [SerializeField] private CoordinatesView _coordinatesView;
    [SerializeField] private InstantaneousSpeedView _instantaneousSpeedView;
    [SerializeField] private LaserRechargeView _laserRechargeView;
    [SerializeField] private LaserShotView _laserShotView;
    [SerializeField] private GameOverView _gameOverView;
    
    public override void InstallBindings()
    {
        BindAngleRotationView();
        BindAngleRotationViewAdapter();
        
        BindCoordinatesView();
        BindCoordinatesViewAdapter();
        
        BindInstantaneousSpeedView();
        BindInstantaneousSpeedViewAdapter();
        
        BindLaserRechargeView();
        BindLaserRechargeViewAdapter();
        
        BindLaserShotView();
        BindLaserShotViewAdapter();
        
        BindGameOverView();
        BindGameOverPresenter();
    }

    private void BindAngleRotationView()
    {
        Container.Bind<AngleRotationView>().FromInstance(_angleRotationView).AsSingle();
    }
    
    private void BindAngleRotationViewAdapter()
    {
        Container.BindInterfacesAndSelfTo<AngleRotationViewAdapter>().AsSingle();
    }

    private void BindCoordinatesView()
    {
        Container.Bind<CoordinatesView>().FromInstance(_coordinatesView).AsSingle();
    }
    
    private void BindCoordinatesViewAdapter()
    {
        Container.BindInterfacesAndSelfTo<CoordinatesViewAdapter>().AsSingle();
    }

    private void BindInstantaneousSpeedView()
    {
        Container.Bind<InstantaneousSpeedView>().FromInstance(_instantaneousSpeedView).AsSingle();
    }
    
    private void BindLaserRechargeViewAdapter()
    {
        Container.BindInterfacesAndSelfTo<LaserRechargeViewAdapter>().AsSingle();
    }
    
    private void BindLaserRechargeView()
    {
        Container.Bind<LaserRechargeView>().FromInstance(_laserRechargeView).AsSingle();
    }
    
    private void BindLaserShotViewAdapter()
    {
        Container.BindInterfacesAndSelfTo<LaserShotViewAdapter>().AsSingle();
    }
    
    private void BindLaserShotView()
    {
        Container.Bind<LaserShotView>().FromInstance(_laserShotView).AsSingle();
    }
    
    private void BindInstantaneousSpeedViewAdapter()
    {
        Container.BindInterfacesAndSelfTo<InstantaneousSpeedViewAdapter>().AsSingle();
    }
    
    private void BindGameOverView()
    {
        Container.Bind<GameOverView>().FromInstance(_gameOverView).AsSingle();
    }
    
    private void BindGameOverPresenter()
    {
        Container.BindInterfacesAndSelfTo<GameOverPresenter>().AsSingle();
    }
}
