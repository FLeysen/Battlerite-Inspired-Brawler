using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : Observer
{
    private List<Status> _statuses = new List<Status>();

    private void Start()
    {
        PlayerMessenger messenger = GetComponent<PlayerMessenger>();
        messenger.AddObserver(this);

        foreach (System.Type status in PossibleStatuses.instance.playerStatuses)
        {
            _statuses.Add((Status)status.GetConstructor(System.Type.EmptyTypes).Invoke(null));
            _statuses[_statuses.Count - 1].ProvidePlayerMessenger(messenger);
        }
    }

    private void Update()
    {
        foreach(Status status in _statuses)
        {
            if (status.IsActive()) status.Update();
        }
    }

    public override void OnNotify<T, Y>(T source, int eventIndex, params Y[] args)
    {
        if (eventIndex != (int)PlayerEvent.EnterStatus) return;

        TripleWithKey<System.Type, float, float, float> arg = args[0] as TripleWithKey<System.Type, float, float, float>;
        foreach (Status status in _statuses)
        {
            if (status.GetType() != arg.key) continue;
            status.TryEnter(arg.first, arg.second, arg.third);
            return;
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
}
