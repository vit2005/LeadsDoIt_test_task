using UnityEngine;

public class CarMoveController : MonoBehaviour, IUpdatable
{
    [SerializeField] private Transform car;

    private float horizontalAcceleration = 0;
    private float verticalAcceleration = 0;

    public const float HORIZONTAL_MOVING_SPEED_MULTIPLIER = 10f;
    public const float VERTICAL_MOVING_SPEED_MULTIPLIER = 1f;
    public const float MAX_LEFT = -0.8f;
    public const float MAX_RIGHT = 0.8f;
    public const float MAX_BOTTOM = 1f;
    public const float MAX_UP = 8f;

    private Vector3 _initialPosition;

    public void Init()
    {
        _initialPosition = car.transform.localPosition;
    }

    public void Restart()
    {
        car.transform.localPosition = _initialPosition;
    }

    public void OnUpdate()
    {
        var x = car.transform.localPosition.x;
        x += horizontalAcceleration * Time.deltaTime * (SpeedController.speed / 1000f);
        x = Mathf.Clamp(x, MAX_LEFT, MAX_RIGHT);

        var y = car.transform.localPosition.y;
        y += verticalAcceleration * Time.deltaTime;
        y = Mathf.Clamp(y, MAX_BOTTOM, MAX_UP);

        car.transform.localPosition = new Vector3(x, y, 0);
    }

    public void LeftStartHolding()
    {
        if (GameController.Instance.CurrentGameMode != GameModeId.Gameplay) return;
        horizontalAcceleration = -HORIZONTAL_MOVING_SPEED_MULTIPLIER;
    }

    public void LeftStopHolding()
    {
        if (horizontalAcceleration < 0) horizontalAcceleration = 0f;
    }

    public void RightStartHolding()
    {
        if (GameController.Instance.CurrentGameMode != GameModeId.Gameplay) return;
        horizontalAcceleration = HORIZONTAL_MOVING_SPEED_MULTIPLIER;
    }

    public void RightStopHolding()
    {
        if (horizontalAcceleration > 0) horizontalAcceleration = 0f;
    }

    public void StartHoldingMove()
    {
        if (GameController.Instance.CurrentGameMode != GameModeId.Gameplay) return;
        verticalAcceleration = VERTICAL_MOVING_SPEED_MULTIPLIER;
    }

    public void StopHoldingMove()
    {
        verticalAcceleration = 0f;
    }

    public void StartHoldingStop()
    {
        if (GameController.Instance.CurrentGameMode != GameModeId.Gameplay) return;
        verticalAcceleration = -VERTICAL_MOVING_SPEED_MULTIPLIER * 3f;
    }

    public void StopHoldingStop()
    {
        verticalAcceleration = 0f;
    }
}