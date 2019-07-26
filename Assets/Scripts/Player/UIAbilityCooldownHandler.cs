using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAbilityCooldownHandler : MonoBehaviour
{
    [SerializeField] private UICooldownInbetween _cooldownInbetween = null;

    public void SetValue(int idx, float percentage, float time)
    {
        _cooldownInbetween.GetValueText()[idx].text = time.ToString();
        _cooldownInbetween.GetRadials()[idx].fillAmount = percentage;
    }
}
