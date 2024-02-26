using System;
using UnityEngine;

public class Bush : MonoBehaviour
{
    private Action<Bush> _release;
    public bool isRightSide;

    public void Init(Action<Bush> release)
    {
        _release = release;
    }

    void Update()
    {
        if (transform.position.y < -1f)
        {
            _release.Invoke(this);
        }
    }
}
