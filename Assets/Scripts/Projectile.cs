using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _range = 5.0f;
    [SerializeField] private float _velocity = 10.0f;
    private Vector3 _startPos = Vector3.zero;
    private Transform _source = null;

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

    public Vector3 GetDisplacement()
    {
        return transform.forward * 4f;
    }

    public float GetDisplacementDuration()
    {
        return 0.1f;
    }

    public string GetName()
    {
        return "Placeholder";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.transform == _source)
            {
                return;
            }
            else
            {
                //TODO: Fill
                //other.GetComponent<Movable>().AddDisplacement(transform.forward * 4f, 0.1f);
                other.GetComponent<PlayerMessenger>().Notify(this, (int)PlayerEvent.Knockback);
            }
        }
        Destroy(gameObject);
    }
}
