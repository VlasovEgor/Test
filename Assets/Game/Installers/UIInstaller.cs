using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{   
    [SerializeField] private AngleRotationView _angleRotationView;
    [SerializeField] private CoordinatesView _coordinatesView;
    [SerializeField] private InstantaneousSpeedView _instantaneousSpeedView;
    
    public override void InstallBindings()
    {
        BindAngleRotationView();
        BindAngleRotationViewAdapter();
        
        BindCoordinatesView();
        BindCoordinatesViewAdapter();
        
        BindInstantaneousSpeedView();
        BindInstantaneousSpeedViewAdapter();
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
    
    private void BindInstantaneousSpeedViewAdapter()
    {
        Container.BindInterfacesAndSelfTo<InstantaneousSpeedViewAdapter>().AsSingle();
    }
}
