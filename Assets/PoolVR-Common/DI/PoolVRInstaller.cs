using UniRx;
using UnityEngine;
using Zenject;

public class PoolVRInstaller : MonoInstaller<PoolVRInstaller>
{
    public GvrViewer gvrViewerPrefab;
    public float triangleSignalPeriod;

    public override void InstallBindings()
    {
        Container.Bind<IObservable<float>>().FromInstance(GeneratedSignals.CreateTriangleSignal(triangleSignalPeriod));
        Container.Bind<ForceSelector>().AsSingle();
        Container.Bind<StageStats>().AsSingle();

        Container.Bind<GvrViewer>().FromPrefab(gvrViewerPrefab);
    }
}