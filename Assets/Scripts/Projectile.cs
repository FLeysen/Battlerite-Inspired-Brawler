using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _range = 5.0f;
    [SerializeField] private float _velocity = 10.0f;
    [SerializeField] private float _damage = 18.0f;
    private Vector3 _startPos = Vector3.zero;
    private Transform _source = null;
    private float _knockbackDuration = 0.3f;
    private string _name = "Incap";

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

    private Vector3 GetDisplacement()
    {
        return transform.forward * 4f;
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
                PlayerMessenger messenger = other.GetComponent<PlayerMessenger>();
                messenger.Notify(this, (int)PlayerEvent.Knockback, new PairWithKey<string, Vector3, float>(_name, GetDisplacement(), _knockbackDuration));
                messenger.Notify(this, (int)PlayerEvent.HealthChange, -_damage);
            }
        }
        Destroy(gameObject);
    }
}
