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
                .Replace(new Movable
                {
                    Displacement = Vector3.zero,
                    Transform = obj.transform,
                    Rigidbody2D = obj.GetComponent<Rigidbody2D>()
                })
                .Replace(new Player());
        }
    }
}