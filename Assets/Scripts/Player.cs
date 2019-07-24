using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string characterName = "UNDEFINED_PLAYER_CHARACTER";
    public int team = 0;
    public int positionInTeam = 0;

    private void Start()
    {
        GameInfoManager.instance.AddPlayer(this);
    }

    public bool IsIndexSmaller(Player other)
    {
        if (team == other.team)
            return positionInTeam < other.positionInTeam;
        else
            return team < other.team;
    }
}
