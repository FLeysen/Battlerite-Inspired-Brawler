using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatusType
{
    Undefined = 0, //No status should ever be of this type
    Negative = 1,
    Beneficial = 2,
}

public abstract class Status
{
    public abstract StatusType GetStatusType();

    protected bool _isActive = false;
    public bool IsActive()
    {
        return _isActive;
    }

    public abstract void Update(PlayerEventMessenger playerEventMessenger);

    public bool TryExit()
    {
        bool wasActive = _isActive;
        _isActive = false;
        return wasActive;
    }
}

public class AblazeStatus : Status
{
    private GameObject _source = null;
    private float _duration = 0f;
    private float _damage = 0f;
    private float _ticks = 0f;
    private float _tickInterval = 0f;
    private float _timeSinceLastTick = 0f;

    public bool TryEnter(float duration, float ticks, float tickDamage, GameObject source)
    {
        if (_duration > duration && _damage < tickDamage) return false;

        _duration = duration;
        _ticks = ticks;
        _tickInterval = _duration / _ticks;
        _damage = tickDamage;
        _timeSinceLastTick = 0f;
        _source = source;
        _isActive = true;

        return true;
    }

    public override void Update(PlayerEventMessenger playerEventMessenger)
    {
        _timeSinceLastTick += Time.deltaTime;
        _duration -= Time.deltaTime;
        if (_timeSinceLastTick > _tickInterval)
        {
            _timeSinceLastTick -= _tickInterval;
            playerEventMessenger.SendHealthChangeEvent(_source, "Ablaze", -_damage, HealthChangeType.DOT);

            if (--_ticks == 0) _isActive = false;
        }
    }

    public override StatusType GetStatusType()
    {
        return StatusType.Negative & StatusType.Undefined;
    }
}