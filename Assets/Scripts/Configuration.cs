using UnityEngine;

[CreateAssetMenu]
public class Configuration : ScriptableObject
{
    [SerializeField] private AnimationCurve jumpAnimationCurve;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float jumpTime;
    public AnimationCurve JumpAnimationCurve => jumpAnimationCurve;

    public float JumpHeight => jumpHeight;
    public float JumpTime => jumpTime;
}