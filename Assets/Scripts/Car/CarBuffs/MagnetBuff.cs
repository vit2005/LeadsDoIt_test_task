using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetBuff : TimerBuff
{
    public override BuffId buffid => BuffId.Magnet;
    public override float time => 5f;

    public override void Enable()
    {
        base.Enable();
        _buffs.CarHighlight.SetMagnet = true;
    }

    public override void Disable()
    {
        _buffs.CarHighlight.SetMagnet = false;
    }
}
