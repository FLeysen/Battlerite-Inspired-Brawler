using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerStatsHandler : MonoBehaviour
{
    [SerializeField] private Text _name = null;
    [SerializeField] private Text _title = null;
    [SerializeField] private Text _character = null;
    [SerializeField] private Text _score = null;
    [SerializeField] private Text _damage = null;
    [SerializeField] private Text _healing = null;
    [SerializeField] private Text _disables = null;
    [SerializeField] private Image _icon = null;
    private float _damageDealt = 0f;
    private float _healingDone = 0f;
    private float _disableScore = 0f;

    public void ProvideData(PlayerInfo player, User user)
    {
        _character.text = player.characterName;
        _name.text = user.userName;
        _title.text = user.title;
        _icon.sprite = CharacterIconGrabber.instance.Get(player.characterName);
    }

    public void AddDamageDealt(float amount)
    {
        _damageDealt += amount;
        _damage.text = ((int)_damageDealt).ToString();
        _score.text = ((int)(_damageDealt + _healingDone + _disableScore)).ToString();
    }

    public void AddHealingDone(float amount)
    {
        _healingDone += amount;
        _healing.text = ((int)_healingDone).ToString();
        _score.text = ((int)(_damageDealt + _healingDone + _disableScore)).ToString();
    }

    public void AddDisableScore(float amount)
    {
        _disableScore += amount;
        _disables.text = ((int)_disableScore).ToString();
        _score.text = ((int)(_damageDealt + _healingDone + _disableScore)).ToString();
    }
}
