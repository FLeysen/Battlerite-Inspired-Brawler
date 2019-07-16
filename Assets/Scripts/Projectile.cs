using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _range = 5.0f;
    [SerializeField] private float _velocity = 10.0f;
    private Vector3 _startPos = Vector3.zero;
    private Transform _source = null;

    public Transform GetSource()
    {
        return _source;
    }

    private void Start()
    {
        _source = transform.parent;
        transform.SetParent(null, true);
        transform.forward = _source.forward;
        _startPos = transform.position;
    }

    private void Update()
    {
        transform.position += _velocity * transform.forward * Time.deltaTime;

        if ((transform.position - _startPos).sqrMagnitude > _range * _range)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == _source)
            return;
        Destroy(gameObject);
    }
}
