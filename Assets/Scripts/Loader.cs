using Leopotam.Ecs;
using Systems;
using UnityEngine;

sealed class Loader : MonoBehaviour {
    private EcsWorld _world;
    private EcsSystems _systems;
    [SerializeField] private Configuration configuration;

    private void Start () {
        _world = new EcsWorld ();
        _systems = new EcsSystems (_world);
#if UNITY_EDITOR
        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
        _systems
            // register your systems here, for example:
            .Add(new PlayerInitSystem())
            .Add(new PlayerInputSystem())
            .Add(new MoveSystem())
            .Add(new JumpSystem())
                
            // register one-frame components (order is important), for example:
            // .OneFrame<TestComponent1> ()
            // .OneFrame<TestComponent2> ()
                
            // inject service instances here (order doesn't important), for example:
            // .Inject (new CameraService ())
            .Inject(configuration)
            .Init ();
    }

    private void Update () {
        _systems?.Run ();
    }

    private void OnDestroy () {
        _systems?.Destroy ();
        _systems = null;
        _world?.Destroy ();
        _world = null;
    }
}