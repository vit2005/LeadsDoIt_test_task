using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroGameplayObject : GameplayObject
{
    public override bool isPositive => true;

    public override bool hideOnTrigger => true;

    public override ObjectType objectType => ObjectType.Nitro;

    public override BuffId? AutoApplyBuffId => BuffId.Nitro;
}
