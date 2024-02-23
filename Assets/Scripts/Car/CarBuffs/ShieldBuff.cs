using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBuff : TimerBuff
{
    public override BuffId buffid => BuffId.Shield;
    public override float time => 5f;

    public override void Enable()
    {
        base.Enable();
        _buffs.CarHighlight.SetShield = true;
    }

    public override void Disable()
    {
        _buffs.CarHighlight.SetShield = false;
    }
}
