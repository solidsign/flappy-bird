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
        private static readonly int Hide = Animator.StringToHash("_hide");
        private static readonly int Show = Animator.StringToHash("_show");

        public LoseScreenAnimationSystem(Animator loseScreenAnimator)
        {
            _animator = loseScreenAnimator;
        }

        public void Run()
        {
            if (_shown && !_restart.IsEmpty())
            {
                _animator.SetTrigger(Hide);
                _shown = false;
                return;
            }

            if (!_shown && !_gameOver.IsEmpty())
            {
                _animator.SetTrigger(Show);
                _shown = true;
                return;
            }
        }
    }
}