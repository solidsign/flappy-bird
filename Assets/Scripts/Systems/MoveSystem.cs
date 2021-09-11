using Components;
using Leopotam.Ecs;

namespace Systems
{
    public class MoveSystem : IEcsRunSystem
    {
        private EcsFilter<MoveComponents ,Movable> _filter;
        public void Run()
        {
            foreach (var i in _filter)
            {
                var mov = _filter.Get1(i);
                var displacement = _filter.Get2(i).Displacement;
                if (displacement.magnitude > 0f)
                {
                    mov.Rigidbody2D.MovePosition(mov.Transform.position + displacement);
                }
            }
        }
    }
}