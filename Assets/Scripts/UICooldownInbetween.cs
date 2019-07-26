using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICooldownInbetween : MonoBehaviour
{
    [SerializeField] private List<Image> _radials = null;
    [SerializeField] private List<Text> _values = null;

    public List<Image> GetRadials()
    {
        return _radials;
    }

    public List<Text> GetValueText()
    {
        return _values;
    }
}
