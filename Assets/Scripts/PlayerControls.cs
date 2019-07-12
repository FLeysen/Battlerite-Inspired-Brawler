using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : Singleton<PlayerControls>
{
    public KeyCode moveF { get; set; } = KeyCode.W;
    public KeyCode moveL { get; set; } = KeyCode.A;
    public KeyCode moveB { get; set; } = KeyCode.S;
    public KeyCode moveR { get; set; } = KeyCode.D;
    public KeyCode ability0 { get; set; } = KeyCode.Mouse0;
    public KeyCode ability1 { get; set; } = KeyCode.Mouse1;
    public KeyCode ability2 { get; set; } = KeyCode.E;

    private void Awake()
    {
        //TODO: add playerprefs parsing to this
        //moveF = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("moveF", KeyCode.W.ToString()));
    }
}