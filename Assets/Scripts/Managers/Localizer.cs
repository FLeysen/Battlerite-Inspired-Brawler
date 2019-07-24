using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Localizer : Singleton<Localizer>
{
    private Dictionary<string, string> _localizations = new Dictionary<string, string>();

    private void Awake()
    {
        //TODO: Add playerprefs to this
        Localize("en_uk");
    }

    private void Localize(string language)
    {
        _localizations.Clear();
        string path = "Assets/Resources/Localization/" + language + ".txt";
        StreamReader reader = new StreamReader(path);
        string line = "";
        string[] data = new string[2];
        while(!reader.EndOfStream)
        {
            line = reader.ReadLine();
            data = line.Split(';');
            _localizations[data[0]] = data[1];
        }

        reader.Close();
    }

    public string Get(string key)
    {
        return _localizations[key];
    }
}
