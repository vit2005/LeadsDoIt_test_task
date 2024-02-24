using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class SlowGameplayObject : GameplayObject
{
    public override bool isPositive => false;

    public override bool hideOnTrigger => false;

    public override ObjectType objectType => ObjectType.Slow;

    public override BuffId? AutoApplyBuffId => BuffId.Slow;

    public override void Init()
    {
        base.Init();
        transform.Rotate(0f, 0f, UnityEngine.Random.Range(0f, 360f));
        transform.localScale = Vector3.one * UnityEngine.Random.Range(0.15f, 0.18f);
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        collision.GetComponent<CarHP>().isDamaging = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<CarHP>().isDamaging = false;
    }
}
