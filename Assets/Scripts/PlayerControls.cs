using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : Singleton<PlayerControls>
{
    public KeyCode p1MoveF { get; set; } = KeyCode.W;
    public KeyCode p1MoveL { get; set; } = KeyCode.A;
    public KeyCode p1MoveB { get; set; } = KeyCode.S;
    public KeyCode p1MoveR { get; set; } = KeyCode.D;
    public KeyCode p1Simple { get; set; } = KeyCode.Mouse0;
    public KeyCode p1Ability1 { get; set; } = KeyCode.Mouse1;
    public KeyCode p1Ability2 { get; set; } = KeyCode.E;

    private void Awake()
    {
        //TODO: add playerprefs parsing to this
        //_p1MoveF = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("p1MoveF", KeyCode.Joystick2Button0.ToString()));
    }
}