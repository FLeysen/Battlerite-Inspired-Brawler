using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossibleStatuses : Singleton<PossibleStatuses>
{
    public List<System.Type> playerStatuses { get; set; } = new List<System.Type>();

    //TODO: REMOVE TEST CODE
    private void Awake()
    {
        playerStatuses.Add(typeof(AblazeStatus));
    }
}
