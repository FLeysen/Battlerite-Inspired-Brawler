using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] private float _gravity = 9.81f;
    [SerializeField] private float _runAccel = 10.0f;
    [SerializeField] private float _maxRunVelocity = 5.0f;
    private List<TripleWithKey<string, Vector3, float, float>> _displacements = new List<TripleWithKey<string, Vector3, float, float>>();
    private List<PairWithKey<string, float, float>> _velocityModifiers = new List<PairWithKey<string, float, float>>();
    private CharacterController _controller = null;
    private Vector3 _velocity = Vector3.zero;
    private Vector3 _displacement = Vector3.zero;
    private float _runVelocity = 0f;

    public void AddDisplacement(Vector3 displacement, float timeToReach, string origin = "")
    {
        _displacements.Add(new TripleWithKey<string, Vector3, float, float>(origin, displacement, timeToReach, timeToReach));
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

    /// <summary>
    /// Adds a modifier to the final velocity calculation.
    /// </summary>
    /// <param name="origin">Use if ending boost/slow can be handled manually</param>
    /// <param name="factor">Above 1f is a boost, below is a slow (e.g.: 0.8f will result in a 20% slow, 1.2f will result in a 20% boost)</param>
    /// <param name="duration">Duration of the modifier</param>
    public void AddMovementModifier(float factor, float duration, string origin = "")
    {
        _velocityModifiers.Add(new PairWithKey<string, float, float>(origin, factor, duration));
    }

    public void RemoveMovementModifier(string origin, bool removeAll = false)
    {
        for (int i = 0; i < _velocityModifiers.Count;)
        {
            if (_velocityModifiers[i].key != origin)
                ++i;
            else
            {
                _velocityModifiers.RemoveAt(i);
                if (removeAll) continue;
                return;
            }
        }
    }

    private float CalculateModifier()
    {
        float result = 1f;
        foreach (PairWithKey<string, float, float> pair in _velocityModifiers)
            result *= pair.first;

        return result;
    }

    private void UpdateModifier()
    {
        for (int i = 0; i < _velocityModifiers.Count;)
        {
            if (_velocityModifiers[i].second < 0f)
                _velocityModifiers.RemoveAt(i);
            else
                _velocityModifiers[i++].second -= Time.deltaTime;
        }
    }

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        UpdateModifier();
        UpdateDisplacement();

        Vector2 movement = Vector2.zero;
        movement.y += Input.GetKey(PlayerControls.instance.moveF) ? 1f : 0f;
        movement.y -= Input.GetKey(PlayerControls.instance.moveB) ? 1f : 0f;
                                  
        movement.x += Input.GetKey(PlayerControls.instance.moveR) ? 1f : 0f;
        movement.x -= Input.GetKey(PlayerControls.instance.moveL) ? 1f : 0f;

        Vector3 forward = Camera.main.transform.forward;
        forward.y = 0f;
        Vector3 right = Camera.main.transform.right;
        forward *= movement.y;
        right *= movement.x;
        forward += right;
        forward = forward.normalized;

        if (movement.x != 0f || movement.y != 0f)
        {
            _runVelocity += _runAccel * Time.deltaTime;
            if (_runVelocity > _maxRunVelocity) _runVelocity = _maxRunVelocity;

            _velocity = new Vector3(forward.x * _runVelocity, _velocity.y, forward.z * _runVelocity);
        }
        else
        {
            _velocity.x = 0f;
            _velocity.z = 0f;
        }

        _velocity *= CalculateModifier();

        /*
        if ((_controller.collisionFlags & CollisionFlags.Below) != 0)
        {
            _velocity.y -= _gravity * Time.deltaTime;
        }
        else
            _velocity.y = 0f;
        */

        CalculateDisplacement();
        _displacement += _velocity * Time.deltaTime;
        _controller.Move(_displacement);
        _displacement = Vector3.zero;
    }
};
