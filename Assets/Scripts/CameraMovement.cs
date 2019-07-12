using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _smoothTime = 0.25f;
    [SerializeField] private Transform _target = null;
    [SerializeField] private Vector3 _cameraDistance = Vector3.zero;
    [SerializeField] private Vector2 _maxUnlockedDistance = Vector2.zero;
    [SerializeField] private Vector2 _maxMouseDistance = Vector2.zero;
    private Vector3 _velocity = Vector3.zero;
    public bool isUnlocked { get; set; } = true;

    void Update()
    {
        Vector3 targetPos = _target.position + _cameraDistance;

        if (isUnlocked)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector2 addedDistance = Vector2.zero;
            addedDistance.x = Mathf.Clamp((mousePos.x - Screen.width * 0.5f) / Screen.width, -_maxMouseDistance.x, _maxMouseDistance.x);
            addedDistance.y = Mathf.Clamp((mousePos.y - Screen.height * 0.5f) / Screen.height, -_maxMouseDistance.y, _maxMouseDistance.y);
            addedDistance.x += addedDistance.x / _maxMouseDistance.x * _maxUnlockedDistance.x;
            addedDistance.y += addedDistance.y / _maxMouseDistance.y * _maxUnlockedDistance.y;
            targetPos.x += addedDistance.x;
            targetPos.z += addedDistance.y;
        }

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref _velocity, _smoothTime);
    }
}
