using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RespawnCharacter))]
public class DummyDeath : MonoBehaviour, DeathEventReceiver
{
    [SerializeField] private float _respawnDelay = 3.0f;
    [SerializeField] private GameObject _deadModel = null;
    private RespawnCharacter _respawner = null;

    private void Start()
    {
        GetComponent<PlayerEventMessenger>().AddDeathReceiver(this);
        _respawner = GetComponent<RespawnCharacter>();
    }

    public void ReceiveDeathEvent(GameObject source, string sourceName)
    {
        //TODO: Animate death
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        _deadModel.SetActive(true);
        Invoke("Respawn", _respawnDelay);
    }

    private void Respawn()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        _deadModel.SetActive(false);
        GetComponent<PlayerHealth>().RestoreToMax();
        GetComponent<PlayerStatus>().ClearAll();
        _respawner.Execute();
    }
}
