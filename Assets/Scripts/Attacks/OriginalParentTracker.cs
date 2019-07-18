using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginalParentTracker : MonoBehaviour
{
    private Transform _source = null;

    public Transform GetSource()
    {
        return _source;
    }

    private void Awake()
    {
        _source = transform.parent;
    }
}
