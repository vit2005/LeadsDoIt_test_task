public class SlowBuff : Buff
{
    public override BuffId buffid => BuffId.Slow;

    public override void Enable()
    {
        GameController.Instance.SpeedController.StartSlow();
        _buffs.VanishBuff(buffid);
    }
}
