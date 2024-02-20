using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    [SerializeField] private SpeedController speedController;
    [SerializeField] private CarMoveController carController;
    [SerializeField] private ButtonHandler move;
    [SerializeField] private ButtonHandler stop;
    [SerializeField] private ButtonHandler left;
    [SerializeField] private ButtonHandler right;

    public void Init()
    {
        move.onPointerDown += speedController.StartHoldingMove;
        move.onPointerUp += speedController.StopHoldingMove;
        stop.onPointerDown += speedController.StartHoldingStop;
        stop.onPointerUp += speedController.StopHoldingStop;

        move.onPointerDown += carController.StartHoldingMove;
        move.onPointerUp += carController.StopHoldingMove;
        stop.onPointerDown += carController.StartHoldingStop;
        stop.onPointerUp += carController.StopHoldingStop;

        left.onPointerDown += carController.LeftStartHolding;
        left.onPointerUp += carController.LeftStopHolding;
        right.onPointerDown += carController.RightStartHolding;
        right.onPointerUp += carController.RightStopHolding;
    }

    public void Update()
    {
        
    }
}
