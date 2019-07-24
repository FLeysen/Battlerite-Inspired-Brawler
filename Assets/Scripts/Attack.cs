using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    [SerializeField] private Material _playerMat = null;
    [SerializeField] private float _cooldown = 0.35f;
    [SerializeField] protected float _castTime = 0.1f;
    [SerializeField] private float _cancelCooldown = 0.1f;
    [SerializeField] private float _movementSlowPercent = 0.5f; 
    [SerializeField] private int _maxCharges = 1;
    protected PlayerMovement _movement = null;
    private PlayerAttacks _attacks = null;
    private float _cooldownTimer = 0.0f;
    private float _cancelCooldownTimer = 0.0f;
    protected float _castTimer = 0.0f;
    private int _charges = 1;
    private bool _isCasting = false;
    private bool _wasCanceled = false;

    public void ManualUpdate()
    {
        if (!_isCasting)
            UpdateNotCasting();
        else
            UpdateCasting();
    }

    private void Start()
    {
        _movement = GetComponentInParent<PlayerMovement>();
        _attacks = GetComponentInParent<PlayerAttacks>();
    }

    public bool AttemptInitiate()
    {
        if (_charges == 0 || _wasCanceled) return false; //TODO: Cooldown animation? Or should be handled elsewhere?
        _isCasting = true;
        _movement.AddMovementModifier(_movementSlowPercent, _castTime, "Casting"); 
        _castTimer = 0.0f;
        return true;
    }

    private void UpdateCasting()
    {
        _castTimer += Time.deltaTime;

        Color playerCol = _playerMat.GetColor("_Color");
        playerCol.g = _castTimer / _castTime;
        playerCol.r = 0.0f;
        playerCol.b = playerCol.r;
        _playerMat.SetColor("_Color", playerCol);

        if (_castTimer > _castTime)
        {
            --_charges;
            if (_cooldownTimer < 0.0f) _cooldownTimer = _cooldown;
            OnCastFinish();
        }
    }

    protected abstract void OnCastFinish();

    public void Cancel(bool activateCancelCooldown = false)
    {
        _wasCanceled = activateCancelCooldown;
        _movement.RemoveMovementModifier("Casting");
        _attacks.activeAttackID = -1;
        _isCasting = false;
        _playerMat.SetColor("_Color", Color.white);
    }

    protected void UpdateNotCasting()
    {
        _cooldownTimer -= Time.deltaTime;

        if (_charges < _maxCharges && _cooldownTimer < 0.0f)
        {
            ++_charges;
            _cooldownTimer += _cooldown;
        }

        if (_wasCanceled)
        {
            _cancelCooldownTimer += Time.deltaTime;
            if (_cancelCooldownTimer > _cancelCooldown)
            {
                _cancelCooldownTimer = 0f;
                _wasCanceled = false;
            }
        }
    }
}
