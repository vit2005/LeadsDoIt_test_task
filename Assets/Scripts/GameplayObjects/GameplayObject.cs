using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Slow,
    Block,
    
    Coins,
    Heart,
    Magnet,
    Shield,

}

public abstract class GameplayObject : MonoBehaviour
{

    public abstract bool isPositive { get; }
    public abstract ObjectType objectType { get; }

    public virtual void Init()
    {
        gameObject.SetActive(true);
    }

    public virtual void Clear()
    {
        gameObject.SetActive(false);
    }
}
