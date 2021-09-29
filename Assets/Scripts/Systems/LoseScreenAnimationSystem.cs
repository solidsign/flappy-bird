using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class LoseScreenAnimationSystem : IEcsRunSystem
    {
        private EcsFilter<RestartEvent> _restart;
        private EcsFilter<Dead> _gameOver;
        [EcsIgnoreInject] private Animator _animator;
        private bool _shown = false;
        public LoseScreenAnimationSystem(Animator loseScreenAnimator)
        {
            _animator = loseScreenAnimator;
        }

        public void Run()
        {
            if (_shown && !_restart.IsEmpty())
            {
                _animator.SetTrigger("_hide");
                _shown = false;
                return;
            }

            if (!_shown && !_gameOver.IsEmpty())
            {
                _animator.SetTrigger("_show");
                _shown = true;
                return;
            }
        }
    }
}