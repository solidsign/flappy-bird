using UnityEngine;

[CreateAssetMenu]
public class Configuration : ScriptableObject
{
    [Header("Jump properties")]
    [SerializeField] private float jumpHeight;
    [SerializeField] private float jumpTime;
    [Tooltip("X and Y should be between 0 and 1")]
    [SerializeField] private AnimationCurve jumpAnimationCurve;

    [Header("Fall properties")]
    [SerializeField] private float fallSpeed;
    [Tooltip("Y should be between 0 and 1")]
    [SerializeField] private AnimationCurve fallSpeedAnimationCurve;

    public AnimationCurve JumpAnimationCurve => jumpAnimationCurve;

    public float JumpHeight => jumpHeight;
    public float JumpTime => jumpTime;

    public float FallSpeed => fallSpeed;

    public AnimationCurve FallSpeedAnimationCurve => fallSpeedAnimationCurve;
}