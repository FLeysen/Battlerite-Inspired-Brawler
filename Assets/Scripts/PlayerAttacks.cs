using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField] private int _attackCount = 3;
    [Tooltip("Attacks will be bound in order of: simple, ability1, ability2")]
    [SerializeField] private Attack[] _attacks = new Attack[0];

    private void Update()
    {
        if (Input.GetKey(PlayerControls._instance.p1Simple))
        {
            if (CheckAndExecute(0)) return;
        }
        // TODO: Other attacks
    }

    private void OnValidate()
    {
        if (_attacks.Length != _attackCount)
        {
            Debug.LogWarning("Attack count and size of attack array should match");
            System.Array.Resize(ref _attacks, _attackCount);
        }
    }

    private bool CheckAndExecute(int idx)
    {
        return _attacks[idx].AttemptInitiate();
    }
}
