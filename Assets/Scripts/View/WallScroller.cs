using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScroller : MonoBehaviour
{
    [SerializeField] private Material _material;
    private float _speed;
    private Vector2 _offset;
    private GameManager _gameManager;

    private void OnEnable()
    {
        _material.mainTextureOffset = Vector2.zero;
    }

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _speed = (float)_gameManager.GameSpeed;
    }

    private void Update()
    {
        float x = _offset.x + Time.deltaTime * _speed;
        _offset.Set(x, 0f);

        _material.mainTextureOffset = _offset;
    }
}
