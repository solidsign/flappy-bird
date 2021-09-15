using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        public void Init()
        {
            var player = _world.NewEntity();
            var obj = GameObject.FindGameObjectWithTag("Player");
            player
                .Replace(new Player())
                .Replace(new Movable
                {
                    Displacement = Vector3.zero,
                })
                .Replace(new MoveComponents
                {
                    Transform = obj.transform,
                    Rigidbody2D = obj.GetComponent<Rigidbody2D>()
                });
            obj.GetComponent<PlayerDeath>().Entity = player;
        }
    }
}