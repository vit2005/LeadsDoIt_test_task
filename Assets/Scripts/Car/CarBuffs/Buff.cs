using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuffId
{
    Slow,
    Magnet,
    Shield,
    Nitro,

}

public abstract class Buff
{
    protected CarBuffs _buffs; 

    public virtual void Init(CarBuffs buffs) { _buffs = buffs; }

    public abstract BuffId buffid { get; }
    public abstract void Enable();
    public virtual void Disable() { }
    public virtual void OnUpdate() { }

}
