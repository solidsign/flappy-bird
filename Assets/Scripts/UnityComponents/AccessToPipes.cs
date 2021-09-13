using System;
using UnityEngine;

public class AccessToPipes : MonoBehaviour
{
    [SerializeField] private Transform upperPipe;
    [SerializeField] private Transform bottomPipe;

    public Transform BottomPipe => bottomPipe;

    public Transform UpperPipe => upperPipe;
}