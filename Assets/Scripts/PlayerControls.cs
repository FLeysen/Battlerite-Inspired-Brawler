using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : Singleton<PlayerControls>
{
    public KeyCode moveF { get; set; } = KeyCode.W;
    public KeyCode moveL { get; set; } = KeyCode.A;
    public KeyCode moveB { get; set; } = KeyCode.S;
    public KeyCode moveR { get; set; } = KeyCode.D;
    public KeyCode[] abilities { get; set; } = new KeyCode[6] { KeyCode.Mouse0, KeyCode.Mouse1, KeyCode.Q, KeyCode.E, KeyCode.R, KeyCode.F };
    public KeyCode cancel { get; set; } = KeyCode.Mouse4;

    private void Awake()
    {
        //TODO: add playerprefs parsing to this
        //moveF = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("moveF", KeyCode.W.ToString()));
    }
}