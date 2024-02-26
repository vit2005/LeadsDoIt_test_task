using TMPro;
using UnityEngine;

public class SpeedController : MonoBehaviour, IPauseHandler, IUpdatable
{
    public const float MAX_SPEED = 1000f;
    public const float MOVING_SPEED_MULTIPLIER = 1000f;
    public const float NITRO_SPEED = 500f;

    private static float _speed;

    private float _maxSpeed = MAX_SPEED;
    private float _minSpeed = 0;
    private float _prePauseSpeed;
    private float _acceleration = 0;

    [SerializeField] private TextMeshProUGUI _speedText;
    public static float speed => _speed;

    public bool SetNitro
    {
        set
        {
            _minSpeed = value ? NITRO_SPEED : 0f;
            _maxSpeed = value ? NITRO_SPEED + MAX_SPEED : MAX_SPEED;
            _speedText.color = value ? Color.cyan : Color.white;
        }
    }

    public void ForceStop()
    {
        _speed = 0;
        _speedText.text = "0";
    }

    public void OnUpdate()
    {
        _speed = Mathf.Clamp(_speed + _acceleration * Time.deltaTime, _minSpeed, _maxSpeed);
        _speedText.text = (Mathf.RoundToInt(speed / 5f)).ToString();
    }

    public void StartHoldingMove()
    {
        if (GameController.Instance.CurrentGameMode != GameModeId.Gameplay) return;
        _acceleration = MOVING_SPEED_MULTIPLIER;
    }

    public void StartHoldingStop()
    {
        _acceleration = -MOVING_SPEED_MULTIPLIER / 2f;
    }

    public void StartSlow()
    {
        _speed /= 2f;
    }

    public void StopHoldingMove()
    {
        _acceleration = 0f;
    }

    public void StopHoldingStop()
    {
        _acceleration = 0f;
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