using Components;
using Leopotam.Ecs;
using Services;
using Systems;
using UnityComponents;
using UnityEngine;

sealed class Loader : MonoBehaviour {
    private EcsWorld _world;
    private EcsSystems _systems;
    private Timer _timer;
    [SerializeField] private Configuration configuration;
    [SerializeField] private UI ui;
    private void Start () {
        _world = new EcsWorld ();
        _systems = new EcsSystems (_world);
        _timer = new Timer();
#if UNITY_EDITOR
        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
        _systems
            .Add(new GameOverSystem())
            .Add(new RestartGameSystem())
            
            .Add(new PlayerInitSystem())
            .Add(new ObstacleInitSystem())
            
            .Add(new PlayerInputSystem())
            .Add(new MoveSystem())
            .Add(new JumpSystem())
            .Add(new PlayerFallSystem())
            
            .Add(new ObstaclePoolingSystem())
            .Add(new ObstacleDeactivateSystem())
            .Add(new ObstacleSpawnSystem())
            .Add(new ObstacleMoveSystem())
            
            
                
            // register one-frame components (order is important), for example:
            .OneFrame<RestartEvent>()
                
            // inject service instances here (order doesn't important), for example:
            .Inject(configuration)
            .Inject(ui)
            .Inject(_timer)
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