using Components;
using Leopotam.Ecs;

namespace Systems
{
    public class MoveSystem : IEcsRunSystem
    {
        private EcsFilter<Movable> _filter;
        public void Run()
        {
            foreach (var i in _filter)
            {
                var mov = _filter.Get1(i);
                if (mov.Displacement.magnitude > 0f)
                {
                    mov.Rigidbody2D.MovePosition(mov.Transform.position + mov.Displacement);
                }
            }
        }
    }
}