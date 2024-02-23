using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsGameplayObject : GameplayObject
{
    public override bool isPositive => true;

    public override bool hideOnTrigger => false;

    public override ObjectType objectType => ObjectType.Coins;
}
