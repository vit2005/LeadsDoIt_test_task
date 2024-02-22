using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowGameplayObject : GameplayObject
{
    public override bool isPositive => false;

    public override ObjectType objectType => ObjectType.Slow;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("SlowGameplayObject");
    }
}
