using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedController : MonoBehaviour, IPauseHandler, IUpdatable
{
    public static float speed => _speed;
    private static float _speed;

    [SerializeField] TextMeshProUGUI _speedText;

    private float acceleration = 0;
    public const float MOVING_SPEED_MULTIPLIER = 1000f;
    public const float MAX_SPEED = 1000f;
    public const float NITRO_SPEED = 500f;
    private float _minSpeed = 0;
    private float _maxSpeed = MAX_SPEED;
    public bool SetNitro
    {
        set
        {
            _minSpeed = value ? NITRO_SPEED : 0f;
            _maxSpeed = value ? NITRO_SPEED + MAX_SPEED : MAX_SPEED;
            _speedText.color = value ? Color.blue : Color.white;
        }
    }

    float _prePauseSpeed;

    public void OnUpdate()
    {
        _speed = Mathf.Clamp(_speed + acceleration * Time.deltaTime, _minSpeed, _maxSpeed);
        _speedText.text = (Mathf.RoundToInt(speed / 5f)).ToString();
    }

    public void StartHoldingMove()
    {
        if (GameController.Instance.CurrentGameMode != GameModeId.Gameplay) return;
        acceleration = MOVING_SPEED_MULTIPLIER;
    }

    public void StopHoldingMove() 
    {
        acceleration = 0f;
    }

    public void StartHoldingStop()
    {
        acceleration = -MOVING_SPEED_MULTIPLIER/2f;
    }

    public void StopHoldingStop()
    {
        acceleration = 0f;
    }

    public void StartSlow()
    {
        _speed /= 2f;
    }

    public void ForceStop()
    {
        _speed = 0;
        _speedText.text = "0";
    }

    public void Pause()
    {
        _prePauseSpeed = _speed;
        _speed = 0;
    }

    public void UnPause()
    {
        _speed = _prePauseSpeed;
    }

}
