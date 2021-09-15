using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsFilter<Player>.Exclude<Dead> _filter;
        public void Run()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;
            foreach (var i in _filter)
            {
                ref var player = ref _filter.GetEntity(i);
                player.Replace(new JumpEvent{JustCalled = true});
            }
        }
    }
}