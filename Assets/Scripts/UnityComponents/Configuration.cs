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
        [SerializeField] private float difficultyChangePeriodLength;
        [Header("Gap Size")]
        [SerializeField] private float gapSpreading;
        [Tooltip("Size will vary from (gapSize - gapSpreading) to (gapSize + gapSpreading). X should be between 0 and 1")]
        [SerializeField] private AnimationCurve gapSizeAnimationCurve;
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
    }
}