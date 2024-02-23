using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoveController : MonoBehaviour
{
    [SerializeField] Transform car;

    private float horizontalAcceleration = 0;
    private float verticalAcceleration = 0;
    public const float HORIZONTAL_MOVING_SPEED_MULTIPLIER = 10f;
    public const float VERTICAL_MOVING_SPEED_MULTIPLIER = 1f;
    public const float MAX_LEFT = -0.8f;
    public const float MAX_RIGHT = 0.8f;
    public const float MAX_BOTTOM = 1f;
    public const float MAX_UP = 8f;

    public void Init()
    {

    }

    public void Update()
    {
        var x = car.transform.localPosition.x;
        x += horizontalAcceleration * Time.deltaTime * (SpeedController.speed / 1000f);
        x = Mathf.Clamp(x, MAX_LEFT, MAX_RIGHT);

        var y = car.transform.localPosition.y;
        y += verticalAcceleration * Time.deltaTime;
        y = Mathf.Clamp(y, MAX_BOTTOM, MAX_UP);

        car.transform.localPosition = new Vector3 (x, y, 0);
    }

    public void LeftStartHolding()
    {
        horizontalAcceleration = -HORIZONTAL_MOVING_SPEED_MULTIPLIER;
    }

    public void LeftStopHolding()
    {
        horizontalAcceleration = 0f;
    }

    public void RightStartHolding()
    {
        horizontalAcceleration = HORIZONTAL_MOVING_SPEED_MULTIPLIER;
    }

    public void RightStopHolding()
    {
        horizontalAcceleration = 0f;
    }

    public void StartHoldingMove()
    {
        verticalAcceleration = VERTICAL_MOVING_SPEED_MULTIPLIER;
    }

    public void StopHoldingMove()
    {
        verticalAcceleration = 0f;
    }

    public void StartHoldingStop()
    {
        verticalAcceleration = -VERTICAL_MOVING_SPEED_MULTIPLIER*3f;
    }

    public void StopHoldingStop()
    {
        verticalAcceleration = 0f;
    }
}
