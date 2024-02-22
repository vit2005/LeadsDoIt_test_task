using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsGameplayObject : GameplayObject
{
    public override bool isPositive => true;

    public override ObjectType objectType => ObjectType.Coins;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("CoinsGameplayObject");
    }
}
