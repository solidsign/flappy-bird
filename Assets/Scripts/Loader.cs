using System.Collections.Generic;
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
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Configuration configuration;
    [SerializeField] private UI ui;
    [SerializeField] private ScoreUI scoreUI;
    [Header("Parallax")]
    [SerializeField] private ParalaxSettings foregroundSettings;
    [SerializeField] private Transform fgObj1;
    [SerializeField] private Transform fgObj2;
    [SerializeField] private ParalaxSettings backgroundSettings;
    [SerializeField] private Transform bgObj1;
    [SerializeField] private Transform bgObj2;
    [Header("Audio")]
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private List<AudioClip> jumpSounds;
    [SerializeField] private List<AudioClip> scoreSounds;
    [SerializeField] private List<AudioClip> highscoreSounds;
    [SerializeField] private List<AudioClip> loseSounds;
    private void Start () {
        _world = new EcsWorld ();
        _systems = new EcsSystems (_world);
        
        _timer = new Timer();
        
        _world.NewEntity().Replace(new ParalaxObject() {Obj1 = fgObj1, Obj2 = fgObj2, Settings = foregroundSettings});
        _world.NewEntity().Replace(new ParalaxObject() {Obj1 = bgObj1, Obj2 = bgObj2, Settings = backgroundSettings});
        
#if UNITY_EDITOR
        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
        _systems
            .Add(new PlayerInputSystem())
            .Add(new GameOverSystem())
            .Add(new RestartGameSystem())
            
            .Add(new PlayerInitSystem())
            .Add(new ObstacleInitSystem())
            
            .Add(new MoveSystem())
            .Add(new JumpSystem())
            .Add(new PlayerFallSystem())
            
            .Add(new ObstaclePoolingSystem())
            .Add(new ObstacleDeactivateSystem())
            .Add(new ObstacleSpawnSystem())
            .Add(new ObstacleMoveSystem())
            
            .Add(new ScoreSystem())
            
            .Add(new SoundPlaySystem<JumpSound>(sfxSource, jumpSounds))
            .Add(new SoundPlaySystem<LoseSound>(sfxSource, loseSounds))
            .Add(new SoundPlaySystem<ScoreSound>(sfxSource, scoreSounds))
            .Add(new SoundPlaySystem<HighscoreSound>(sfxSource, highscoreSounds))
            
            .Add(new ParalaxSystem())
                
            // register one-frame components (order is important), for example:
            .OneFrame<JumpSound>()
            .OneFrame<LoseSound>()
            .OneFrame<ScoreSound>()
            .OneFrame<HighscoreSound>()
            .OneFrame<JumpInputEvent>()
            .OneFrame<RestartEvent>()

                
            // inject service instances here (order doesn't important), for example:
            .Inject(configuration)
            .Inject(ui)
            .Inject(scoreUI)
            .Inject(_timer)
            .Inject(playerAnimator)
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