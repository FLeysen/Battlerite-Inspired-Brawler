using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface KnockbackEventReceiver
{
    void ReceiveKnockbackEvent(GameObject source, string sourceName, Vector3 distance, float duration);
}

public interface HealthChangeEventReceiver
{
    void ReceiveHealthChangeEvent(GameObject source, string sourceName, float damage, HealthChangeType type);
}

public interface DeathEventReceiver
{
    void ReceiveDeathEvent(GameObject source, string sourceName);
}

public interface SetAblazeEventReceiver
{
    void ReceiveSetAblazeEvent(GameObject source, string sourceName, float duration, float ticks, float tickDamage);
}