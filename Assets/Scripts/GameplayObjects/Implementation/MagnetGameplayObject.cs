using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetGameplayObject : GameplayObject
{
    public override bool isPositive => true;

    public override bool hideOnTrigger => true;

    public override ObjectType objectType => ObjectType.Magnet;

    public override BuffId? AutoApplyBuffId => BuffId.Magnet;
}
