using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartGameplayObject : GameplayObject
{
    public override bool isPositive => false;

    public override ObjectType objectType => ObjectType.Heart;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HeartGameplayObject");
    }
}
