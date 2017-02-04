using UniRx;
using UnityEngine;
using Zenject;

public class PoolVRInstaller : MonoInstaller<PoolVRInstaller>
{
    public GvrViewer gvrViewer;
    public float triangleSignalPeriod;

    public override void InstallBindings()
    {
        Container.Bind<ForceSelector>().FromInstance(new ForceSelector(triangleSignalPeriod));
        Container.Bind<StageStatistics>().AsSingle();
        Container.Bind<GvrViewer>().FromInstance(gvrViewer);
        Container.BindAllInterfacesAndSelf<GameplayCompleteAction>().To<GameplayCompleteAction>().AsSingle();
        Container.BindAllInterfacesAndSelf<VRModeSetter>().To<VRModeSetter>().AsSingle();
    }
}