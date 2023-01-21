using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private Vector3 _playerSpawnPosition;
    [SerializeField] private Obstacle _obstacle;
    [SerializeField] private Vector3 _obstacleSpawnPosition;

    private GameManager _gameManager;
    private ObjectPool<Obstacle> _obstaclePool;
    private float _positionX = 0;
    private float _gameSpeed;

    void Start()
    {
        _gameManager = GameManager.Instance;
        _gameSpeed = (float)_gameManager.GameSpeed;
        _obstaclePool = new(CreateObject, OnGetObject, OnReliseObject, OnDestroyObject);
        Instantiate(_player, _playerSpawnPosition, Quaternion.identity, transform);
    }

    void Update()
    {
        _positionX += Time.deltaTime * _gameSpeed;

        if (_positionX >= _gameManager.GameConfig.ObstacleDistance)
        {
            _positionX = 0;
            _obstaclePool.Get();
        }
    }

    private Obstacle CreateObject()
    {
        Obstacle obstacle = Instantiate(_obstacle, transform.position, Quaternion.identity, transform);
        obstacle.gameObject.SetActive(false);
        obstacle.SetPool(_obstaclePool);
        return obstacle;
    }

    private void OnGetObject(Obstacle obstacle)
    {
        float y = Random.Range(-1, 2);
        obstacle.transform.position = new Vector3(_obstacleSpawnPosition.x, y);
        obstacle.gameObject.SetActive(true);
    }

    private void OnReliseObject(Obstacle obstacle)
    {
        obstacle.gameObject.SetActive(false);
    }

    private void OnDestroyObject(Obstacle obstacle)
    {
        Destroy(obstacle.gameObject);
    }
}
