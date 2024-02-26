using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DebugInput : MonoBehaviour
{
    [SerializeField] public UnityEvent leftStart;
    [SerializeField] public UnityEvent leftStop;
    [SerializeField] public UnityEvent rightStart;
    [SerializeField] public UnityEvent rightStop;
    [SerializeField] public List<UnityEvent> stopStart;
    [SerializeField] public List<UnityEvent> stopStop;
    [SerializeField] public List<UnityEvent> moveStart;
    [SerializeField] public List<UnityEvent> moveStop;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) leftStart.Invoke();
        if (Input.GetKeyDown(KeyCode.RightArrow)) rightStart.Invoke();
        if (Input.GetKeyUp(KeyCode.LeftArrow)) leftStop.Invoke();
        if (Input.GetKeyUp(KeyCode.RightArrow)) rightStop.Invoke();

        if (Input.GetKeyDown(KeyCode.DownArrow)) foreach (var action in stopStart) { action.Invoke(); }
        if (Input.GetKeyDown(KeyCode.UpArrow)) foreach (var action in moveStart) { action.Invoke(); }
        if (Input.GetKeyUp(KeyCode.DownArrow)) foreach (var action in stopStop) { action.Invoke(); }
        if (Input.GetKeyUp(KeyCode.UpArrow)) foreach (var action in moveStop) { action.Invoke(); }
    }
}
