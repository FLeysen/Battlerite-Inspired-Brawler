using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackOnHit : MonoBehaviour
{
    [SerializeField] private float _damage = 18.0f;
    [SerializeField] private float _knockbackDistance = 4.0f;
    [SerializeField] private float _knockbackDuration = 0.1f;
    [SerializeField] private string _name = "";

    private Vector3 CalculateDisplacement()
    {
        return transform.forward * _knockbackDistance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.transform == GetComponent<OriginalParentTracker>().GetSource())
                return;
            PlayerEventMessenger messenger = other.GetComponent<PlayerEventMessenger>();
             messenger.SendKnockbackEvent(gameObject, _name, CalculateDisplacement(), _knockbackDuration);
             messenger.SendHealthChangeEvent(gameObject, _name, -_damage, HealthChangeType.Generic);
        }
    }
}
