using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inflammatory : MonoBehaviour
{
    [SerializeField] float _duration = 2.0f;
    [SerializeField] float _ticks = 10.0f;
    [SerializeField] float _damage = 2.0f;
    [SerializeField] string _name = "";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.transform == GetComponent<OriginalParentTracker>().GetSource())
                return;
            PlayerEventMessenger messenger = other.GetComponent<PlayerEventMessenger>();
             messenger.SendSetAblazeEvent(gameObject, _name, _duration, _ticks, _damage);
        }
    }
}
