using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float _verticalSpeed;
    private PlayerInput _input;
    private GameManager _gameManager;
    private float _verticalSpeedTimer;
    private float _gameTimer;
    private Vector2 _position;
    private int _verticalMoveDirection = -1;

    private void Awake()
    {
        _input = new PlayerInput();
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.Main.MoveUp.started += MoveUp;
        _input.Main.MoveUp.canceled += MoveDown;
    }

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _verticalSpeed = (float)_gameManager.GameSpeed / 2;
        _verticalSpeedTimer = 0;
        _gameTimer = 0;
    }

    private void Update()
    {
        _verticalSpeedTimer += Time.deltaTime;
        if (_verticalSpeedTimer >= _gameManager.GameConfig.SpeedChangeTimer)
        {
            _verticalSpeedTimer = 0;
            _verticalSpeed += _gameManager.GameConfig.VerticalSpeedIncrement;
        }

        _gameTimer += Time.deltaTime;

        float y = transform.position.y + _verticalSpeed * Time.deltaTime * _verticalMoveDirection;
        _position.Set(transform.position.x, y);
        transform.position = _position;
    }

    private void MoveUp(InputAction.CallbackContext context)
    {
        _verticalMoveDirection = 1;
    }

    private void MoveDown(InputAction.CallbackContext context)
    {
        _verticalMoveDirection = -1;
    }

    private void OnDisable()
    {
        _input.Disable();
        _input.Main.MoveUp.performed -= MoveUp;
        _input.Main.MoveUp.canceled -= MoveDown;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            _gameManager.GameOver(_gameTimer);
        }
    }
}
