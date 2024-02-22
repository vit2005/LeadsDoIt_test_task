using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameplayObject : MonoBehaviour
{
    public virtual void Init()
    {
        gameObject.SetActive(true);
    }

    public virtual void Clear()
    {
        gameObject.SetActive(false);
    }
}
