using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectileToss : Attack
{
    [SerializeField] private GameObject _projectile = null;

    protected override void OnCastFinish()
    {
        Cancel();
        Instantiate(_projectile, transform.parent);

    }
}
