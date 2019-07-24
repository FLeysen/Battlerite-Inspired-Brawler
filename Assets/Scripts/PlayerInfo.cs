using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public string characterName = "UNDEFINED_PLAYER_CHARACTER";
    public int team = 0;
    public int positionInTeam = 0;

    private void Start()
    {
        PlayerInfoManager.instance.AddPlayer(this);
    }

    public bool IsIndexSmaller(PlayerInfo other)
    {
        if (team == other.team)
            return positionInTeam < other.positionInTeam;
        else
            return team < other.team;
    }
}
