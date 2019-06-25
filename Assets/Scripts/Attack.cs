using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    [SerializeField] private float _cooldown = 0.35f;
    [SerializeField] private int _maxCharges = 1;
    private PlayerMovement _movement = null;
    private PlayerAttacks _attacks = null;
    private float _timer = 0.0f;
    private int _charges = 1;
    private bool _isCasting = false;

    private void ManualUpdate()
    {
        if (!_isCasting)
            UpdateNotCasting();
        else
            UpdateCasting();
    }

    private void Start()
    {
        _movement = GetComponentInParent<PlayerMovement>();
        _attacks = GetComponentInParent<PlayerAttacks>();
    }

    public bool AttemptInitiate()
    {
        if (_charges == 0) return false; //TODO: Cooldown animation? Or should be handled elsewhere?
        InitiateAttack();
        return true;
    }

    protected abstract void UpdateCasting();

    protected abstract void InitiateAttack();

    protected void UpdateNotCasting()
    {
        if (_timer > 0.0f) _timer -= Time.deltaTime;
        else if (_charges < _maxCharges)
        {
            ++_charges;
            _timer += _cooldown;
        }
    }
}
