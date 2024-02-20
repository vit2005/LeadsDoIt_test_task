using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoveController : MonoBehaviour
{
    [SerializeField] Transform car;

    private float horizonytalAcceleration = 0;
    private float verticalAcceleration = 0;
    public const float HORIZONTAL_MOVING_SPEED_MULTIPLIER = 10f;
    public const float VERTICAL_MOVING_SPEED_MULTIPLIER = 10f;
    public const float MAX_LEFT = -200f;
    public const float MAX_RIGHT = 200f;

    public void Init()
    {

    }

    public void Update()
    {
        car.transform.position += Mathf.Clamp(horizonytalAcceleration * Time.deltaTime, MAX_LEFT, MAX_RIGHT) * Vector3.right;
    }

    public void LeftStartHolding()
    {
        horizonytalAcceleration = -HORIZONTAL_MOVING_SPEED_MULTIPLIER;
    }

    public void LeftStopHolding()
    {
        horizonytalAcceleration = 0f;
    }

    public void RightStartHolding()
    {
        horizonytalAcceleration = HORIZONTAL_MOVING_SPEED_MULTIPLIER;
    }

    public void RightStopHolding()
    {
        horizonytalAcceleration = 0f;
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
        verticalAcceleration = -VERTICAL_MOVING_SPEED_MULTIPLIER;
    }

    public void StopHoldingStop()
    {
        verticalAcceleration = 0f;
    }
}
