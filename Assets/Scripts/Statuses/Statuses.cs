using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Status
{
    protected PlayerMessenger _playerMessenger = null;

    public void ProvidePlayerMessenger(PlayerMessenger playerMessenger)
    {
        _playerMessenger = playerMessenger;
    }

    protected bool _isActive = false;
    public bool IsActive()
    {
        return _isActive;
    }

    public abstract bool TryEnter(float argA, float argB, float argC);

    public abstract void Update();

    public bool TryExit()
    {
        bool wasActive = _isActive;
        _isActive = false;
        return wasActive;
    }
}

public class AblazeStatus : Status
{
    private float _duration = 0f;
    private float _damage = 0f;
    private float _ticks = 0f;
    private float _tickInterval = 0f;
    private float _timeSinceLastTick = 0f;

    public override bool TryEnter(float argA, float argB, float argC)
    {
        if (_duration > argA && _damage < argC) return false;

        _duration = argA;
        _ticks = argB;
        _tickInterval = _duration / _ticks;
        _damage = argC;
        _timeSinceLastTick = 0f;
        _isActive = true;

        return true;
    }

    public override void Update()
    {
        _timeSinceLastTick += Time.deltaTime;
        _duration -= Time.deltaTime;
        if (_timeSinceLastTick > _tickInterval)
        {
            _timeSinceLastTick -= _tickInterval;
            _playerMessenger.Notify(this, (int)PlayerEvent.HealthChange, -_damage);

            if (--_ticks == 0) _isActive = false;
        }
    }
}