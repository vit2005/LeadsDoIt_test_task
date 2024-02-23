using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowGameplayObject : GameplayObject
{
    public override bool isPositive => false;

    public override bool hideOnTrigger => false;

    public override ObjectType objectType => ObjectType.Slow;

    public override BuffId? AutoApplyBuffId => BuffId.Slow;
}
