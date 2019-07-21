using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour, SetAblazeEventReceiver
{
    private PlayerEventMessenger _eventMessenger = null;
    private AblazeStatus _ablazeStatus = new AblazeStatus();
    private List<Status> _statuses = new List<Status>();

    private void Start()
    {
        _eventMessenger = GetComponent<PlayerEventMessenger>();
        _eventMessenger.AddSetAblazeReceiver(this);
        _statuses.Add(_ablazeStatus);
    }

    private void Update()
    {
        foreach(Status status in _statuses)
        {
            if (!status.IsActive()) continue;
            status.Update(_eventMessenger);
        }
    }

    public bool IsStatusActive(System.Type statusType)
    {
        foreach (Status status in _statuses)
        {
            if (status.GetType() == statusType) return status.IsActive();
        }
        return false;
    }

    public void ReceiveSetAblazeEvent(GameObject source, string sourceName, float duration, float ticks, float tickDamage)
    {
        _ablazeStatus.TryEnter(duration, ticks, tickDamage);
    }

    public int ClearStatesOfType(StatusType type)
    {
        int amtCleared = 0;
        foreach (Status status in _statuses)
        {
            if ((status.GetStatusType() & type) != StatusType.Undefined)
            {
                if (status.TryExit()) ++amtCleared;
            }
        }
        return amtCleared;
    }

    public int ClearAll()
    {
        int amtCleared = 0;
        foreach (Status status in _statuses)
        {
            if (status.TryExit()) ++amtCleared;
        }
        return amtCleared;
    }
}
