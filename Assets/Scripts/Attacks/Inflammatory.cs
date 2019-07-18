using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inflammatory : MonoBehaviour
{
    [SerializeField] float _duration = 2.0f;
    [SerializeField] float _ticks = 10.0f;
    [SerializeField] float _damage = 2.0f;

    //TODO: SUPER REMOVE THIS
    private Projectile _projectile = null;

    private void Start()
    {
        _projectile = GetComponent<Projectile>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.transform != _projectile.GetSource())
        {
             PlayerMessenger messenger = other.GetComponent<PlayerMessenger>();
             messenger.Notify(this, (int)PlayerEvent.EnterStatus, new TripleWithKey<System.Type, float, float, float>(typeof(AblazeStatus), _duration, _ticks, _damage));
        }
    }
}
