using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField] private int _attackCount = 3;
    [Tooltip("Attacks will be bound in order of: simple, ability1, ability2")]
    [SerializeField] private Attack[] _attacks = new Attack[0];
    public int activeAttackIDX { get; set; } = -1;

    private void Update()
    {
        foreach(Attack attack in _attacks)
            attack.ManualUpdate();

        //TODO: Cancel functionality, currently hold to keep casting
        //if (activeAttackIDX != -1) return;

        if (Input.GetKey(PlayerControls._instance.p1Simple))
        {
            if (CheckAndExecute(0))
            {
                activeAttackIDX = 0;
                return;
            }
        }
        else if (activeAttackIDX == 0)
        {
            _attacks[0].Cancel();
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
        if (activeAttackIDX != -1) return false; //TODO: Remove temp code
        return _attacks[idx].AttemptInitiate();
    }
}
