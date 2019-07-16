using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    virtual public void Enter() { }
    virtual public void Exit() { }
    virtual public void Update() { }
}
