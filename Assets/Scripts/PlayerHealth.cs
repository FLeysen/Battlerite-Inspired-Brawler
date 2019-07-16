using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Observer
{
    [SerializeField] private float _maxHealth = 230.0f;
    private HealthBar _healthBar = null;
    private float _health = 230.0f;
    private float _maxEffectiveHealth = 230.0f;

    public override void OnNotify<T, Y>(T source, int eventIndex, params Y[] args)
    {
        if (eventIndex != (int)PlayerEvent.HealthChange) return;
        ChangeHealth(System.Convert.ToSingle(args[0]));
    }

    void Start()
    {
        GetComponent<PlayerMessenger>().AddObserver(this);
        _healthBar = GetComponentInChildren<HealthBar>();
        _health = _maxHealth;
        _maxEffectiveHealth = _maxHealth;
    }

    private void ChangeHealth(float amt)
    {
        _health += amt;

        //TODO: Die, update effective max....
        if (_health < 0.0f)
        {
            GetComponent<PlayerMessenger>().Notify(this, (int)PlayerEvent.Death, 0);
            _health = 0.0f;
        }

        _healthBar.OnHealthChange(_health / _maxHealth, _maxEffectiveHealth / _maxHealth);
    }
}
