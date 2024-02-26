public class NitroGameplayObject : GameplayObject
{
    public override bool isPositive => true;

    public override bool hideOnTrigger => true;

    public override ObjectType objectType => ObjectType.Nitro;

    public override BuffId? AutoApplyBuffId => BuffId.Nitro;
}
