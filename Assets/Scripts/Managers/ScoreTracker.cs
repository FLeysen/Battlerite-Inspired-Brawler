using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour, HealthChangeEventReceiver
{
    [SerializeField] private float _distFromEdge = 10.0f;
    [SerializeField] private GameObject _uiElementPrefab = null;
    private UIPlayerStatsHandler[] _uiElements = null;
    private float _boxWidth = 247.4f;
    private float _boxHeight = 222.1f;

    public void ReceiveHealthChangeEvent(GameObject source, string sourceName, float damage, HealthChangeType type)
    {
        Player player = GameInfoManager.instance.GetAttachedPlayer(source);
        int index = GameInfoManager.instance.GetFirstIndexOfTeam(player.team) + player.positionInTeam;
        if ((type & HealthChangeType.Heal) == 0)
            _uiElements[index].AddDamageDealt(-damage);
        else
            _uiElements[index].AddHealingDone(damage);
    }

    private void Start()
    {
        _uiElements = new UIPlayerStatsHandler[GameInfoManager.instance.players.Count];
        for (int i = 0, size = GameInfoManager.instance.players.Count; i < size; ++i)
        {
            GameInfoManager.instance.players[i].GetComponent<PlayerEventMessenger>().AddHealthChangeReceiver(this);
            _uiElements[i] = Instantiate(_uiElementPrefab, transform.parent).GetComponent<UIPlayerStatsHandler>();
            _uiElements[i].ProvideData(GameInfoManager.instance.players[i], GameInfoManager.instance.users[i]);
            PositionUIElement(GameInfoManager.instance.players[i], _uiElements[i]);
        }
    }

    private void PositionUIElement(Player player, UIPlayerStatsHandler uiElement)
    {
        Vector3 position = Vector2.zero;
        RectTransform rect = uiElement.GetComponent<RectTransform>();
        int positionInTeam = 1 + player.positionInTeam;
        switch (player.team)
        {
            case 0:
                rect.anchorMin = new Vector2(0, 1);
                rect.anchorMax = new Vector2(0, 1);
                position.x += (_distFromEdge + _boxWidth * 0.5f);
                position.y -= (_distFromEdge + _boxHeight * 0.5f) * positionInTeam;
                break;
            case 1:
                rect.anchorMin = new Vector2(1, 1);
                rect.anchorMax = new Vector2(1, 1);
                position.x -= (_distFromEdge + _boxWidth * 0.5f);
                position.y -= (_distFromEdge + _boxHeight * 0.5f) * positionInTeam;
                break;
            case 2:
                rect.anchorMin = new Vector2(0, 0);
                rect.anchorMax = new Vector2(0, 0);
                position.x += (_distFromEdge + _boxWidth * 0.5f);
                position.y += (_distFromEdge + _boxHeight * 0.5f) * positionInTeam;
                break;
            case 3:
                rect.anchorMin = new Vector2(1, 0);
                rect.anchorMax = new Vector2(1, 0);
                position.x -= (_distFromEdge + _boxWidth * 0.5f);
                position.y += (_distFromEdge + _boxHeight * 0.5f) * positionInTeam;
                break;
        }
        rect.anchoredPosition = position;
    }
}
