using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    public static float speed => _speed;
    private static float _speed;

    private float acceleration = 0;
    public const float MOVING_SPEED_MULTIPLIER = 1000f;
    public const float MAX_SPEED = 1000f;

    private void Update()
    {
        _speed = Mathf.Clamp(_speed + acceleration * Time.deltaTime, 0f, MAX_SPEED);
        Debug.Log(_speed);
    }

    public void StartHoldingMove()
    {
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

    public void ForceStop()
    {
        acceleration = -MOVING_SPEED_MULTIPLIER;
        _speed = 0;
    }
}
