using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultPlayerState : State
{}

public class BurningState : State
{
    public PlayerMessenger playerMessenger { get; set; }
    public float damage { get; set; }
    public float ticks { get; set; }
    public float duration { get; set; }

    private float _timeExpired = 0f;
    private float _timeBetweenTicks = 0f;

    public override void Enter()
    {
        _timeBetweenTicks = duration / ticks;
        _timeExpired = 0f;
    }

    override public void Update()
    {
        _timeExpired += Time.deltaTime;
        if (_timeExpired > _timeBetweenTicks)
        {
            _timeExpired -= _timeBetweenTicks;

            if (ticks != 0) //TODO: REMOVE
                playerMessenger.Notify(this, (int)PlayerEvent.HealthChange, -damage);
            else if(--ticks == 0)
            {
                //TODO: Leave state
            }
        }

    }
}

public class PlayerStateMachine : Observer
{
    private State _currentState = null;
    private DefaultPlayerState _defaultState = new DefaultPlayerState();
    private BurningState _burningState = new BurningState();

    private void Start()
    {
        _burningState.playerMessenger = GetComponent<PlayerMessenger>();
        _burningState.playerMessenger.AddObserver(this);
        _currentState = _defaultState;
    }

    private void Update()
    {
        _currentState.Update();
    }

    public override void OnNotify<T, Y>(T source, int eventIndex, params Y[] args)
    {
        /*
        if (eventIndex == (int)PlayerEvent.SetAblaze)
        {
            _burningState.duration = System.Convert.ToSingle(args[0]);
            _burningState.ticks = System.Convert.ToSingle(args[1]);
            _burningState.damage = System.Convert.ToSingle(args[2]);
            TransitionTo(_burningState);
        }
        */
    }

    private void TransitionTo(State newState)
    {
        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }
}
