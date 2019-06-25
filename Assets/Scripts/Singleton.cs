using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _Instance;

    public static T _instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = (T)FindObjectOfType(typeof(T));

                if (_Instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _Instance = singletonObject.AddComponent<T>();
                    singletonObject.name = typeof(T).ToString() + " (Singleton)";

                    DontDestroyOnLoad(singletonObject);
                }
            }
            return _Instance;
        }
    }
    private void Start()
    {
        if (_Instance != null && _Instance != this)
            Destroy(this);
    }
}