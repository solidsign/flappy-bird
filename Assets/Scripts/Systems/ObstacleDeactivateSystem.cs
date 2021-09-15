using Components;
using Leopotam.Ecs;

namespace Systems
{
    public class ObstacleDeactivateSystem : IEcsRunSystem
    {
        private EcsFilter<Obstacle, Pooled> _filter;
        public void Run()
        {
            foreach (var i in _filter)
            {
                _filter.Get1(i).WholeObstacle.gameObject.SetActive(false);
            }
        }
    }
}