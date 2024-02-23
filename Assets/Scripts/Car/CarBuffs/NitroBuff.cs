using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroBuff : TimerBuff
{
    public override BuffId buffid => BuffId.Nitro;
    public override float time => 5f;

    public override void Enable()
    {
        base.Enable();
        _buffs.SpeedController.SetNitro = true;
        _buffs.CarHighlight.SetNitro = true;
    }

    public override void Disable()
    {
        _buffs.SpeedController.SetNitro = false;
        _buffs.CarHighlight.SetNitro = false;
    }
}
