using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBuff : TimerBuff
{
    public override BuffId buffid => BuffId.Shield;
    public override float time => 15f;

    public override void Enable()
    {
        base.Enable();
        _buffs.CarHighlight.SetShield = true;
        _buffs.BarsController.EnableShield = true;
    }

    public override void Disable()
    {
        _buffs.CarHighlight.SetShield = false;
        _buffs.BarsController.EnableShield = false;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        _buffs.BarsController.SetShield = Mathf.Clamp01(currentTime / time);
    }
}
