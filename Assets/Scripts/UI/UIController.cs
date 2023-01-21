using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private GameObject _newGamePanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TMP_Text _attemptsCount;
    [SerializeField] private TMP_Text _timer;
    private GameManager _gameManager;

    void Start()
    {
        OnNewGame();
    }

    private void OnEnable()
    {
        _gameManager = GameManager.Instance;
        _gameManager.OnStartGame += OnStartGame;
        _gameManager.OnGameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _gameManager.OnStartGame -= OnStartGame;
        _gameManager.OnGameOver -= OnGameOver;
    }

    private void OnStartGame()
    {
        _uiPanel.SetActive(false);
    }

    private void OnGameOver(int attempts, float timer)
    {
        _uiPanel.SetActive(true);
        _newGamePanel.SetActive(false);
        _gameOverPanel.SetActive(true);
        _attemptsCount.text = attempts.ToString();
        _timer.text = timer.ToString("#.##") + " sec";
    }

    public void OnNewGame()
    {
        _uiPanel.SetActive(true);
        _newGamePanel.SetActive(true);
        _gameOverPanel.SetActive(false);
    }
}
