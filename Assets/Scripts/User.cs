using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public string userName = "Grudar";
    public string title = "Mainer of Rook";
    public int index = 0;

    private void Start()
    {
        GameInfoManager.instance.AddUser(this);
    }
}
