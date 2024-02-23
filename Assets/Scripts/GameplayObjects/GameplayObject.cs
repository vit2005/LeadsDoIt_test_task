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
    Nitro

}

public abstract class GameplayObject : MonoBehaviour
{

    public abstract bool isPositive { get; }
    public abstract bool hideOnTrigger { get; }
    public abstract ObjectType objectType { get; }
    public virtual BuffId? AutoApplyBuffId { get; } = null;

    public virtual void Init()
    {
        gameObject.SetActive(true);
    }

    public virtual void Clear()
    {
        gameObject.SetActive(false);
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(this.GetType().ToString());
        if (hideOnTrigger) gameObject.SetActive(false);
        CarBuffs buffs = collision.GetComponent<CarBuffs>();
        if (buffs != null && AutoApplyBuffId.HasValue) buffs.ApplyBuff(AutoApplyBuffId.Value);
    }
}
