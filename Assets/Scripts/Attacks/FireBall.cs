using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Projectile))]
public class FireBall : MonoBehaviour
{
    [SerializeField] private float _damage = 18.0f;
    [SerializeField] private float _knockbackDistance = 4.0f;
    [SerializeField] private float _knockbackDuration = 0.1f;
    [SerializeField] private string _name = "Fireball";
    private Projectile _projectile = null;

    private void Start()
    {
        _projectile = GetComponent<Projectile>();
    }

    private Vector3 CalculateDisplacement()
    {
        return transform.forward * _knockbackDistance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.transform == _projectile.GetSource())
            {
                return;
            }
            else
            {
                PlayerMessenger messenger = other.GetComponent<PlayerMessenger>();
                messenger.Notify(this, (int)PlayerEvent.Knockback, new PairWithKey<string, Vector3, float>(_name, CalculateDisplacement(), _knockbackDuration));
                messenger.Notify(this, (int)PlayerEvent.HealthChange, -_damage);
            }
        }
    }
}
