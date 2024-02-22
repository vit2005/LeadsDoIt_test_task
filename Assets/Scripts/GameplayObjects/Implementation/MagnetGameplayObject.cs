using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetGameplayObject : GameplayObject
{
    public override bool isPositive => true;

    public override ObjectType objectType => ObjectType.Magnet;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("MagnetGameplayObject");
    }
}
