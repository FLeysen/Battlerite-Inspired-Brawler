using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventMessenger : MonoBehaviour
{
    #region knockback
    private List<KnockbackEventReceiver> _knockbackEventReceivers = new List<KnockbackEventReceiver>();

    public void AddKnockbackReceiver(KnockbackEventReceiver receiver)
    {
        _knockbackEventReceivers.Add(receiver);
    }

    public void RemoveKnockbackReceiver(KnockbackEventReceiver receiver)
    {
        _knockbackEventReceivers.Remove(receiver);
    }

    public void SendKnockbackEvent(GameObject source, string sourceName, Vector3 distance, float duration)
    {
        foreach (KnockbackEventReceiver knockbackEventReceiver in _knockbackEventReceivers)
            knockbackEventReceiver.ReceiveKnockbackEvent(source, sourceName, distance, duration);
    }
    #endregion

    #region healthChange
    private List<HealthChangeEventReceiver> _healthChangeEventReceivers = new List<HealthChangeEventReceiver>();

    public void AddHealthChangeReceiver(HealthChangeEventReceiver receiver)
    {
        _healthChangeEventReceivers.Add(receiver);
    }

    public void RemoveHealthChangeReceiver(HealthChangeEventReceiver receiver)
    {
        _healthChangeEventReceivers.Remove(receiver);
    }

    public void SendHealthChangeEvent(GameObject source, string sourceName, float damage, HealthChangeType type)
    {
        foreach (HealthChangeEventReceiver healthChangeEventReceiver in _healthChangeEventReceivers)
            healthChangeEventReceiver.ReceiveHealthChangeEvent(source, sourceName, damage, type);
    }
    #endregion

    #region death
    private List<DeathEventReceiver> _deathEventReceivers = new List<DeathEventReceiver>();

    public void AddDeathReceiver(DeathEventReceiver receiver)
    {
        _deathEventReceivers.Add(receiver);
    }

    public void RemoveDeathReceiver(DeathEventReceiver receiver)
    {
        _deathEventReceivers.Remove(receiver);
    }

    public void SendDeathEvent(GameObject source, string sourceName)
    {
        foreach (DeathEventReceiver deathEventReceiver in _deathEventReceivers)
            deathEventReceiver.ReceiveDeathEvent(source, sourceName);
    }
    #endregion

    #region setAblaze
    private List<SetAblazeEventReceiver> _setAblazeEventReceivers = new List<SetAblazeEventReceiver>();

    public void AddSetAblazeReceiver(SetAblazeEventReceiver receiver)
    {
        _setAblazeEventReceivers.Add(receiver);
    }

    public void RemoveSetAblazeReceiver(SetAblazeEventReceiver receiver)
    {
        _setAblazeEventReceivers.Remove(receiver);
    }

    public void SendSetAblazeEvent(GameObject source, string sourceName, float duration, float ticks, float tickDamage)
    {
        foreach (SetAblazeEventReceiver setAblazeEventReceiver in _setAblazeEventReceivers)
            setAblazeEventReceiver.ReceiveSetAblazeEvent(source, sourceName, duration, ticks, tickDamage);
    }
    #endregion
}
