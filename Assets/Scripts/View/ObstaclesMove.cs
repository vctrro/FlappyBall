using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesMove : MonoBehaviour
{
    private float _speed;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _speed = (float)_gameManager.GameSpeed;
    }


    private void Update()
    {
        float x = transform.position.x - Time.deltaTime * _speed;
        transform.position = new Vector3(x, transform.position.y, 0);
    }
}
