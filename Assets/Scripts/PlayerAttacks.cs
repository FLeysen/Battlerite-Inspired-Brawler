using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField] private int _attackCount = 3;
    [Tooltip("Attacks will be bound in order of: simple, ability1, ability2")]
    [SerializeField] private GameObject[] _attacks = new GameObject[0];
    [SerializeField] private float[] _attackCooldowns = new float[0];
    private float[] _attackTimers = null;

    private void Start()
    {
        _attackTimers = new float[_attacks.Length];
        for (int i = 0; i < _attackTimers.Length; ++i)
        {
            _attackTimers[i] = 0.0f;
        }
    }

    private void Update()
    {
        for (int i = 0, size = _attackTimers.Length; i < size; ++i)
        {
            _attackTimers[i] -= Time.deltaTime;
        }

        if (Input.GetKey(PlayerControls._instance.p1Simple))
        {
            CheckAndExecute(0);
        }
    }

    private void OnValidate()
    {
        if (_attacks.Length != _attackCount || _attackCooldowns.Length != _attackCount)
        {
            Debug.LogWarning("Attack count and size of attack array should match");
            System.Array.Resize(ref _attacks, _attackCount);
            System.Array.Resize(ref _attackCooldowns, _attackCount);
        }
    }

    private void CheckAndExecute(int idx)
    {
        if (_attackTimers[idx] > 0.0f) return; //TODO: Effect that indicates cooldown
        _attackTimers[idx] = _attackCooldowns[idx];
        Instantiate(_attacks[idx], transform);
    }
}
