using UnityEngine;

namespace Components
{
    public struct Obstacle
    {
        public Transform WholeObstacle;
        public Rigidbody2D Rigidbody2D;
        public Transform UpperPipe;
        public Transform BottomPipe;
    }
}