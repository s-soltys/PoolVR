using UniRx;
using UnityEngine;
using Zenject;

public class PoolVRInstaller : MonoInstaller<PoolVRInstaller>
{
    public GvrViewer gvrViewerPrefab;
    public float triangleSignalPeriod;

    public override void InstallBindings()
    {
        Container.Bind<ForceSelector>().FromInstance(new ForceSelector(triangleSignalPeriod));
        Container.Bind<StageStatistics>().AsSingle();
        Container.Bind<GvrViewer>().FromPrefab(gvrViewerPrefab);
        Container.BindAllInterfacesAndSelf<GameplayCompleteAction>().To<GameplayCompleteAction>().AsSingle();
    }
}