using UnityEngine;

namespace UnityComponents
{
    [CreateAssetMenu]
    public class Configuration : ScriptableObject
    {
        [Header("Player")]
        [Header("Jump properties")]
        [SerializeField] private float jumpHeight;
        [SerializeField] private float jumpTime;
        [Tooltip("X and Y should be between 0 and 1")]
        [SerializeField] private AnimationCurve jumpAnimationCurve;

        [Header("Fall properties")]
        [SerializeField] private float fallSpeed;
        [Tooltip("Y should be between 0 and 1")]
        [SerializeField] private AnimationCurve fallSpeedAnimationCurve;

        
        [Header("Obstacles")]
        [SerializeField] private AccessToPipes obstaclePrefab;
        [SerializeField] private int obstaclePoolSize;
        [SerializeField] private float difficultyChangePeriodLength;
        [SerializeField] private float minObstaclePosX;
        [SerializeField] private float spawnX;
        [Header("Gap Position")] 
        [SerializeField] private float maxGapY;
        [SerializeField] private float minGapY;
        
        [Header("Gap Size")]
        [SerializeField] private float gapSpreading;
        [Tooltip("Size will vary from (gapSize - gapSpreading) to (gapSize + gapSpreading). X should be between 0 and 1")]
        [SerializeField] private AnimationCurve gapSizeAnimationCurve;
        
        [Header("Distance Between Obstacles")]
        [SerializeField] private float distanceBetweenObstaclesSpreading;
        [Tooltip("Works same as gapSizeAnimationCurve")]
        [SerializeField] private AnimationCurve distanceBetweenObstaclesAnimationCurve;
        
        [Header("Obstacle Speed")]
        [SerializeField] private float defaultObstacleSpeed;
        [Tooltip("X and Y should be between 0 and 1")]
        [SerializeField] private AnimationCurve obstacleSpeedAnimationCurve;

        public AnimationCurve JumpAnimationCurve => jumpAnimationCurve;
        public float JumpHeight => jumpHeight;
        public float JumpTime => jumpTime;
        public float FallSpeed => fallSpeed;
        public AnimationCurve FallSpeedAnimationCurve => fallSpeedAnimationCurve;
        public float DifficultyChangePeriodLength => difficultyChangePeriodLength;
        public float GapSpreading => gapSpreading;
        public AnimationCurve GapSizeAnimationCurve => gapSizeAnimationCurve;
        public float DefaultObstacleSpeed => defaultObstacleSpeed;
        public AnimationCurve ObstacleSpeedAnimationCurve => obstacleSpeedAnimationCurve;
        public float DistanceBetweenObstaclesSpreading => distanceBetweenObstaclesSpreading;
        public AnimationCurve DistanceBetweenObstaclesAnimationCurve => distanceBetweenObstaclesAnimationCurve;
        public AccessToPipes ObstaclePrefab => obstaclePrefab;
        public float MAXGapY => maxGapY;
        public float MINGapY => minGapY;
        public int ObstaclePoolSize => obstaclePoolSize;
        public float MINObstaclePosX => minObstaclePosX;

        public float SpawnX => spawnX;
    }
}