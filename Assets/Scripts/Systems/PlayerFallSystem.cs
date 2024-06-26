﻿using Components;
using Leopotam.Ecs;
using UnityComponents;
using UnityEngine;

namespace Systems
{
    public class PlayerFallSystem : IEcsRunSystem
    {
        private EcsFilter<Player, Movable>.Exclude<Jumping, Dead> _filter;
        private Configuration _config;
        private Animator _playerAnimator;
        private float _timer = 0f;
        private static readonly int Fall = Animator.StringToHash("_fall");
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
                _playerAnimator.SetTrigger(Fall);

                mov.Displacement = new Vector3(0,  -_config.FallSpeed * _config.FallSpeedAnimationCurve.Evaluate(_timer) * Time.deltaTime, 0);
            
                _timer += Time.deltaTime;
            }
        }
    }
}