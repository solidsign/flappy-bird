using Components;
using Leopotam.Ecs;
using UnityComponents;
using UnityEngine;

namespace Systems
{
    public class PlayerFallSystem : IEcsRunSystem
    {
        private EcsFilter<Player, Movable>.Exclude<JumpEvent, Dead> _filter;
        private Configuration _config;

        private float _timer = 0f;
        public void Run()
        {
            if (_filter.IsEmpty())
            {
                _timer = 0f;
                return;
            }
            foreach (var i in _filter)
            {
                ref var mov = ref _filter.Get2(i);


                mov.Displacement = new Vector3(0,  -_config.FallSpeed * _config.FallSpeedAnimationCurve.Evaluate(_timer) * Time.deltaTime, 0);
            
                _timer += Time.deltaTime;
            }
        }
    }
}