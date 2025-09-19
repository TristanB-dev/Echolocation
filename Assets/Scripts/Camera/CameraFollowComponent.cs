using System;
using UnityEngine;

public class CameraFollowComponent : MonoBehaviour
{
    private Vector3 Offset = new Vector3(0, 0, -10f);
    private const float SmoothTime = 0.25f;
    private Vector3 _velocity = Vector3.zero;

    [SerializeField] private Transform target;

    private void Update()
    {
        var targetPosition = target.position + Offset;
        
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, SmoothTime);
    }
}
