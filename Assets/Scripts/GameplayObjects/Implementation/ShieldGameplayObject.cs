using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGameplayObject : GameplayObject
{
    public override bool isPositive => true;

    public override bool hideOnTrigger => true;

    public override ObjectType objectType => ObjectType.Shield;

    public override BuffId? AutoApplyBuffId => BuffId.Shield; 
}