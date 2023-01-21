using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Vector3 _playerSpawnPosition;
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private Vector3 _obstacleSpawnPosition;

    private GameManager _gameManager;
    private float _positionX = 0;
    private float _gameSpeed;

    void Start()
    {
        _gameManager = GameManager.Instance;
        _gameSpeed = (float)_gameManager.GameSpeed;
        Instantiate(_player, _playerSpawnPosition, Quaternion.identity, transform);
    }

    void Update()
    {
        _positionX += Time.deltaTime * _gameSpeed;

        if (_positionX >= _gameManager.GameConfig.ObstacleDistance)
        {
            _positionX = 0;
            float y = Random.Range(-1, 2);
            _obstacleSpawnPosition.Set(_obstacleSpawnPosition.x, y, 0);
            Instantiate(_obstacle, _obstacleSpawnPosition, Quaternion.identity, transform);
        }
    }
}
