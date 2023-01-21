using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private const string GameSceneName = "Game";

    private PlayerRecords _playerRecords;

    public event Action OnStartGame;
    public event Action<int, float> OnGameOver;

    public GameConfig GameConfig { get; private set; }
    public GameSpeed GameSpeed { get => GameConfig.GameSpeed; set => GameConfig.GameSpeed = value; }

    private void Awake()
    {
        Init(GameSpeed.Slow);
    }

    private void Init(GameSpeed gameSpeed)
    {
        GameConfig = new GameConfig(gameSpeed);

        if (PlayerPrefs.HasKey(typeof(PlayerRecords).ToString()))
        {
            _playerRecords = JsonUtility.FromJson<PlayerRecords>(PlayerPrefs.GetString(typeof(PlayerRecords).ToString()));
        }
        else
        {
            _playerRecords = new PlayerRecords();
        }
    }

    private void Save()
    {
        PlayerPrefs.SetString(typeof(PlayerRecords).ToString(), JsonUtility.ToJson(_playerRecords));
        PlayerPrefs.Save();
    }

    public void GameStart()
    {
        SceneManager.LoadSceneAsync(GameSceneName, LoadSceneMode.Additive);
        _playerRecords.AttempsCount++;
        OnStartGame.Invoke();
    }

    public void GameOver(float gameTimer)
    {
        SceneManager.UnloadSceneAsync(GameSceneName);

        OnGameOver.Invoke(_playerRecords.AttempsCount, gameTimer);
    }

    private void OnApplicationPause(bool pause)
    {
        Save();
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}
