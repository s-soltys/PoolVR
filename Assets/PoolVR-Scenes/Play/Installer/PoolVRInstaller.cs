using UniRx;
using UnityEngine;
using Zenject;

public class PoolVRInstaller : MonoInstaller<PoolVRInstaller>
{
    public GvrViewer gvrViewerPrefab;
    public float triangleSignalPeriod;

    public override void InstallBindings()
    {
        Container.Bind<IObservable<float>>().FromInstance(ObservableSignals.CreateTriangleSignal(triangleSignalPeriod));
        Container.Bind<ForceSelector>().AsSingle();
        Container.Bind<StageStatistics>().AsSingle();

        Container.Bind<GvrViewer>().FromPrefab(gvrViewerPrefab);
    }
}