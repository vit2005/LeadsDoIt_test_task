using UnityEngine;

public class MagnetBuff : TimerBuff
{
    public override BuffId buffid => BuffId.Magnet;
    public override float time => 15f;

    public override void Enable()
    {
        base.Enable();
        _buffs.CarHighlight.SetMagnet = true;
        _buffs.BarsController.EnableMagnet = true;
        _buffs.CarMagnet.gameObject.SetActive(true);
    }

    public override void Disable()
    {
        _buffs.CarHighlight.SetMagnet = false;
        _buffs.BarsController.EnableMagnet = false;
        _buffs.CarMagnet.gameObject.SetActive(false);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        _buffs.BarsController.SetMagnet = Mathf.Clamp01(currentTime / time);
    }
}
