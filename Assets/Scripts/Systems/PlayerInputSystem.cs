using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsFilter<Player> _filter = null;
        public void Run()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;
            foreach (var i in _filter)
            {
                ref var player = ref _filter.Get1(i);
                player.PlayerState = PlayerState.Jumped;
            }
        }
    }
}