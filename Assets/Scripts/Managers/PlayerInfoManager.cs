﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoManager : Singleton<PlayerInfoManager>
{
    public List<PlayerInfo> players { get; set; } = new List<PlayerInfo>();
    public List<User> users { get; set; } = new List<User>();
    public int teamCount { get; set; } = 2;
    public int[] playersPerTeam { get; set; } = new int[2] { 1, 1 };

    public int GetFirstIndexOfTeam(int team)
    {
        int result = 0;
        for (int i = 0; i < team; ++i)
            result += playersPerTeam[i];
        return result;
    }

    public void AddPlayer(PlayerInfo player)
    {
        for(int i = 0, size = players.Count; i < size; ++i)
        {
            if (player.IsIndexSmaller(players[i]))
            {
                players.Insert(i, player);
                return;
            }
        }
        players.Add(player);
    }

    public void AddUser(User user)
    {
        for (int i = 0, size = users.Count; i < size; ++i)
        {
            if (user.index < users[i].index)
            {
                users.Insert(i, user);
                return;
            }
        }
        users.Add(user);
    }

    public PlayerInfo GetAttachedPlayer(GameObject toCheck)
    {
        foreach(PlayerInfo player in players)
        {
            if (player.gameObject != toCheck) continue;
            return player;
        }
        return null;
    }

    /*
    public User GetAttachedUser(GameObject toCheck)
    {
        foreach (User user in users)
        {
            if (user.gameObject != toCheck) continue;
            return user;
        }
        return null;
    }
    */
}
