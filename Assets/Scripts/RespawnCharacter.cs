using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RespawnCharacter : MonoBehaviour
{
    private Quaternion _respawnRotation = Quaternion.identity;
    private Vector3 _respawnPosition = Vector3.zero;

    private void Start()
    {
        _respawnPosition = transform.position;
        _respawnRotation = transform.rotation;
    }

    public void SetPositionAndRotation()
    {
        SetPositionAndRotation(transform.position, transform.rotation);
    }

    public void SetPositionAndRotation(Vector3 position)
    {
        SetPositionAndRotation(position, transform.rotation);
    }

    public void SetPositionAndRotation(Quaternion rotation)
    {
        SetPositionAndRotation(transform.position, rotation);
    }

    public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
    {
        _respawnRotation = rotation;
        _respawnPosition = position;
    }

    public void Execute()
    {
        CharacterController characterController = GetComponent<CharacterController>();
        characterController.enabled = false;
        transform.SetPositionAndRotation(_respawnPosition, _respawnRotation);
        characterController.enabled = true;
    }
}
