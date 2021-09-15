using Components;
using Leopotam.Ecs;
using Services;
using UnityComponents;

namespace Systems
{
    public class RestartGameSystem : IEcsRunSystem
    {
        private EcsFilter<RestartEvent> _filter;
        private EcsFilter<Player> _player;
        private EcsFilter<Obstacle> _obstacles;
        private Configuration _config;
        private UI _ui;
        private Timer _timer;
        public void Run()
        {
            if (_filter.IsEmpty()) return;

            foreach (var i in _player)
            {
                ref var pl = ref _player.GetEntity(i);
                pl.Get<MoveComponents>().Transform.position = _config.StartPlayerPosition;
                pl.Del<JumpEvent>();
                pl.Del<Dead>();
            }

            foreach (var i in _obstacles)
            {
                _obstacles.GetEntity(i).Replace(new Pooled());
            }
        
            _ui.HideLoseScreen();
            _timer.Reset();
        }
    }
}