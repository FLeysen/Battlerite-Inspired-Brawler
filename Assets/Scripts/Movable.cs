using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movable : Observer
{
    private List<TripleWithKey<string, Vector3, float, float>> _displacements = new List<TripleWithKey<string, Vector3, float, float>>();
    private CharacterController _controller = null;
    private Vector3 _displacement = Vector3.zero;

    public void AddDisplacement(Vector3 displacement, float timeToReach, string origin = "")
    {
        _displacements.Add(new TripleWithKey<string, Vector3, float, float>(origin, displacement, timeToReach, timeToReach));
    }

    public override void OnNotify<T>(T source, int eventIndex)
    {
        if (eventIndex == (int)PlayerEvent.Knockback)
        {
            Projectile projectile = source as Projectile;
            _displacements.Add(new TripleWithKey<string, Vector3, float, float>(projectile.GetName(), projectile.GetDisplacement(), projectile.GetDisplacementDuration(), projectile.GetDisplacementDuration()));
        }
    }

    public void RemoveDisplacement(string origin, bool removeAll = false)
    {
        for (int i = 0; i < _displacements.Count;)
        {
            if (_displacements[i].key != origin)
                ++i;
            else
            {
                _displacements.RemoveAt(i);
                if (removeAll) continue;
                return;
            }
        }
    }

    private void UpdateDisplacement()
    {
        for (int i = 0; i < _displacements.Count;)
        {
            if (_displacements[i].third == 0f)
                _displacements.RemoveAt(i);
            else
            {
                _displacements[i].second = _displacements[i].third;
                _displacements[i].third -= Time.deltaTime;
                if (_displacements[i].third < 0f)
                    _displacements[i].third = 0f;
                ++i;
            }
        }
    }

    private void CalculateDisplacement()
    {
        foreach (TripleWithKey<string, Vector3, float, float> triple in _displacements)
            _displacement += triple.first * (triple.second - triple.third);
    }

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        GetComponent<PlayerMessenger>().AddObserver(this);
    }

    void Update()
    {
        UpdateDisplacement();
        CalculateDisplacement();
        _controller.Move(_displacement);
        _displacement = Vector3.zero;
    }
}
