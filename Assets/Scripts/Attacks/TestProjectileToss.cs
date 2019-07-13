using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectileToss : Attack
{
    [SerializeField] private GameObject _projectile = null;
    [SerializeField] private float _backDisplaceDistance = 2f;
    [SerializeField] private float _backDisplaceDuration = 0.1f;

    protected override void OnCastFinish()
    {
        Cancel();
        Instantiate(_projectile, transform.parent);
        Vector3 displacement = -_movement.transform.forward;
        displacement.y = 0f;
        _movement.AddDisplacement(displacement * _backDisplaceDistance, _backDisplaceDuration, "ProjectileToss");
    }
}
