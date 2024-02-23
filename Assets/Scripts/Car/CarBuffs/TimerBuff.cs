using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimerBuff : Buff
{
    public abstract float time { get; }
    protected float currentTime;

    public override void Enable()
    {
        if (currentTime > 0f) currentTime += time;
        else currentTime = time;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        currentTime -= Time.deltaTime;
        if (currentTime < 0)
        {
            _buffs.VanishBuff(buffid);
        }
    }
}