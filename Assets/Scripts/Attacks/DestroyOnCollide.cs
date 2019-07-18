using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollide : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == GetComponent<OriginalParentTracker>().GetSource())
            return;
        Destroy(gameObject);
    }
}
