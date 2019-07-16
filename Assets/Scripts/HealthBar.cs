using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Transform _filledBar = null;
    private float _initialSize = 0f;

    void Start()
    {
        _initialSize = _filledBar.localScale.x;
    }

    public void OnHealthChange(float healthPercent, float effectiveMaxPercent)
    {
        _filledBar.localScale = new Vector3(healthPercent * _initialSize, _filledBar.localScale.y, _filledBar.localScale.z);
    }
}
