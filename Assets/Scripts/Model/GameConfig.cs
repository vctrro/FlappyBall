using System;

public enum GameSpeed
{
	Slow = 2,
	Normal = 3,
	Fast = 4
}

public class GameConfig
{
	private readonly int _obstacleDistance = 4;
    private readonly float _speedChangeTimer = 15f;
    private readonly float _verticalSpeedIncrement = 0.2f;

    private GameSpeed _gameSpeed;

    public GameSpeed GameSpeed { get => _gameSpeed; set => _gameSpeed = value; }

    public float SpeedChangeTimer => _speedChangeTimer;
    public int ObstacleDistance => _obstacleDistance;
    public float VerticalSpeedIncrement => _verticalSpeedIncrement;

    public GameConfig (GameSpeed gameSpeed)
	{
		_gameSpeed = gameSpeed;
    }
}

