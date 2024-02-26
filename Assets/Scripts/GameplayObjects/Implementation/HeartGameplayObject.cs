using UnityEngine;

public class HeartGameplayObject : GameplayObject
{
    public override bool isPositive => false;

    public override bool hideOnTrigger => true;

    public override ObjectType objectType => ObjectType.Heart;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        var carHP = collision.GetComponent<CarHP>();
        if (carHP != null) carHP.HP += 0.15f;
    }
}