using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsGameplayObject : GameplayObject
{
    [SerializeField] List<GameObject> coin;

    public override bool isPositive => true;

    public override bool hideOnTrigger => false;

    public override ObjectType objectType => ObjectType.Coins;

    public override void Init()
    {
        base.Init();
        foreach (var coin in coin) { coin.SetActive(true); }
    }
}
