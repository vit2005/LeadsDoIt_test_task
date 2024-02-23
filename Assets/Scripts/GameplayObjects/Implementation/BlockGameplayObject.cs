using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGameplayObject : GameplayObject
{
    public override bool isPositive => false;

    public override bool hideOnTrigger => false;

    public override ObjectType objectType => ObjectType.Block;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
