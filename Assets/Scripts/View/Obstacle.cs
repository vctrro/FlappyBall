using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Obstacle : MonoBehaviour
{
    private float _speed;
    private GameManager _gameManager;
    private ObjectPool<Obstacle> _pool;

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

    public void SetPool(ObjectPool<Obstacle> pool)
    {
        _pool = pool;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            _pool?.Release(this);
        }
    }
}
