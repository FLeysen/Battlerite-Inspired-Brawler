using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HealthChangeType
{
    Generic = 0,
    DOT = 1,
    Heal = 2,
    HealBeyondMax = 4,
}

public class PlayerHealth : MonoBehaviour, HealthChangeEventReceiver
{
    [SerializeField] private float _maxHealth = 230.0f;
    private HealthBar _healthBar = null;
    private float _health = 230.0f;
    private float _maxEffectiveHealth = 230.0f;

    private void Start()
    {
        GetComponent<PlayerEventMessenger>().AddHealthChangeReceiver(this);
        _healthBar = GetComponentInChildren<HealthBar>();
        _health = _maxHealth;
        _maxEffectiveHealth = _maxHealth;
    }

    private void ChangeHealth(float amt, HealthChangeType type)
    {
        _health += amt;

        //TODO: Die, update effective max....
        if (_health < 0.0f)
        {
            GetComponent<PlayerEventMessenger>().SendDeathEvent(gameObject, "PlayerHealth");
            _health = 0.0f;
        }

        _healthBar.OnHealthChange(_health / _maxHealth, _maxEffectiveHealth / _maxHealth);
    }

    public void ReceiveHealthChangeEvent(GameObject source, string sourceName, float damage, HealthChangeType type)
    {
        ChangeHealth(damage, type);
    }

    public void RestoreToMax()
    {
        ChangeHealth(_maxHealth - _health, HealthChangeType.HealBeyondMax);
    }
}
