using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] private float _gravity = 9.81f;
    [SerializeField] private float _runAccel = 10.0f;
    [SerializeField] private float _maxRunVelocity = 5.0f;
    private float _runVelocity = 0f;
    private Vector3 _velocity = Vector3.zero;
    private CharacterController _controller = null;
    public float moveSlow { get; set; } = 0.0f;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 movement = Vector2.zero;
        movement.y += Input.GetKey(PlayerControls._instance.p1MoveF) ? 1f : 0f;
        movement.y -= Input.GetKey(PlayerControls._instance.p1MoveB) ? 1f : 0f;
                                  
        movement.x += Input.GetKey(PlayerControls._instance.p1MoveR) ? 1f : 0f;
        movement.x -= Input.GetKey(PlayerControls._instance.p1MoveL) ? 1f : 0f;

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
        if (moveSlow != 0.0f) _velocity /= moveSlow;

        /*
        if ((_controller.collisionFlags & CollisionFlags.Below) != 0)
        {
            _velocity.y -= _gravity * Time.deltaTime;
        }
        else
            _velocity.y = 0f;
        */
        _controller.Move(_velocity * Time.deltaTime);
    }
};
