using UnityEngine;

public struct Player
{
    public PlayerState PlayerState;
    public float JumpHeight;
    public Transform Transform;
}

public enum PlayerState
{
    Falling, Jumped, Jumping
}