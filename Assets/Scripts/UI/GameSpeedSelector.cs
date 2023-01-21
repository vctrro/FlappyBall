using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeedSelector : MonoBehaviour
{
    [SerializeField] private Button _slowSpeedButton;
    [SerializeField] private Button _normalSpeedButton;
    [SerializeField] private Button _fastSpeedButton;

    [SerializeField] private Color _selectedButton = new Color(0, 19, 180);
    [SerializeField] private Color _unSelectedButton = new Color(0, 100, 170);
    private GameManager _gameManager;
    

    void Start()
    {
        _gameManager = GameManager.Instance;
        _slowSpeedButton.onClick.AddListener(() => OnSelectSpeed(GameSpeed.Slow));
        _normalSpeedButton.onClick.AddListener(() => OnSelectSpeed(GameSpeed.Normal));
        _fastSpeedButton.onClick.AddListener(() => OnSelectSpeed(GameSpeed.Fast));

    }

    public void OnSelectSpeed(GameSpeed gameSpeed)
    {
        _gameManager.GameSpeed = gameSpeed;

        _slowSpeedButton.image.color =
            _normalSpeedButton.image.color =
            _fastSpeedButton.image.color = _unSelectedButton;

        switch (gameSpeed)
        {
            case GameSpeed.Slow:
                _slowSpeedButton.image.color = _selectedButton;
                break;
            case GameSpeed.Normal:
                _normalSpeedButton.image.color = _selectedButton;
                break;
            case GameSpeed.Fast:
                _fastSpeedButton.image.color = _selectedButton;
                break;
        }
    }
}
