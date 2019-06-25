using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private float _rotateTime = 0.1f;
    private float _elapsedTime = 0.0f;
    private float _rotateFactor = 0.0f;
    private Quaternion _previousTarget = Quaternion.identity;

    private void Start()
    {
        _rotateFactor = 1 / _rotateTime;
    }

    private void Update()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(mouseRay, out RaycastHit hitInfo, 10000.0f, LayerMask.GetMask("Floor"));
        Quaternion targetRotation = Quaternion.LookRotation(hitInfo.point - transform.position);
        if (targetRotation != _previousTarget)
        {
            _previousTarget = targetRotation;
            _elapsedTime = 0.0f;
        }
        _elapsedTime += Time.deltaTime;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _elapsedTime * _rotateFactor);
        transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
    }
}
