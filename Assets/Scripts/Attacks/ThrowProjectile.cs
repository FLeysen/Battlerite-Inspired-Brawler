using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowProjectile : Attack
{
    [SerializeField] private GameObject _projectile = null;
    
    protected override void OnCastFinish()
    {
        Cancel();
        Instantiate(_projectile, transform.parent);
    }
}
