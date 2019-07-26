using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField] private int _attackCount = 3;
    [Tooltip("Attacks will be bound in order of: simple, ability1, ability2")]
    [SerializeField] private Attack[] _attacks = new Attack[0];
    public int activeAttackID { get; set; } = -1;
    private UIAbilityCooldownHandler _uiCooldownHandler = null;
    private int _currentlyUpdating = 0;

    private void Start()
    {
        _uiCooldownHandler = GetComponent<UIAbilityCooldownHandler>();
    }

    private void Update()
    {
        _currentlyUpdating = 0;
        foreach(Attack attack in _attacks)
        {
            attack.ManualUpdate(this);
            ++_currentlyUpdating;
        }

        if (activeAttackID != -1)
        {
            if (!Input.GetKeyDown(PlayerControls.instance.cancel))
                return;
            else
                _attacks[activeAttackID].Cancel(true);
        }
        
        for (int i = 0, length = _attacks.Length; i < length; ++i)
        {
            if (Input.GetKey(PlayerControls.instance.abilities[i]))
            {
                if (CheckAndExecute(i))
                {
                    activeAttackID = i;
                    break;
                }
            }
        }
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

    public void AnimateCurrentAttackCooldown(float percentage, float time)
    {
        _uiCooldownHandler.SetValue(_currentlyUpdating, percentage, time);
    }
}
