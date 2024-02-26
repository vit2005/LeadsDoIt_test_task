using UnityEngine;

public class NitroBuff : TimerBuff
{
    public override BuffId buffid => BuffId.Nitro;
    public override float time => 15f;

    public override void Enable()
    {
        base.Enable();
        _buffs.SpeedController.SetNitro = true;
        _buffs.CarHighlight.SetNitro = true;
        _buffs.BarsController.EnableNitro = true;
    }

    public override void Disable()
    {
        _buffs.SpeedController.SetNitro = false;
        _buffs.CarHighlight.SetNitro = false;
        _buffs.BarsController.EnableNitro = false;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        _buffs.BarsController.SetNitro = Mathf.Clamp01(currentTime / time);
    }
}
