using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _smoothTime = 0.25f;
    [SerializeField] private Transform _target = null;
    [SerializeField] private Vector3 _cameraDistance = Vector3.zero;
    private Vector3 _velocity = Vector3.zero;
    public bool isUnlocked { get; set; } = true;

    void Update()
    {
        transform.position = (Vector3.SmoothDamp(transform.position, _target.position + _cameraDistance, ref _velocity, _smoothTime));
    }
}
