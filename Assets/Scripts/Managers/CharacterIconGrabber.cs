using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterIconGrabber : Singleton<CharacterIconGrabber>
{
    private Dictionary<string, Sprite> _mappings = new Dictionary<string, Sprite>();

    public Sprite Get(string name)
    {
        if (!_mappings.ContainsKey(name))
            _mappings[name] = Resources.Load<Sprite>("Sprites/" + Localizer.instance.Get(name + "Icon"));
        return _mappings[name];
    }
}
