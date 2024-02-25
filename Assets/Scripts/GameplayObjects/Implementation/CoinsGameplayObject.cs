using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsGameplayObject : GameplayObject
{
    [SerializeField] List<GameObject> coins;
    private List<Vector3> localPositions = new List<Vector3>();

    public override bool isPositive => true;

    public override bool hideOnTrigger => false;

    public override ObjectType objectType => ObjectType.Coins;

    public void Awake()
    {
        foreach (var coin in coins) localPositions.Add(coin.transform.localPosition);
    }

    public override void Init()
    {
        base.Init();
        for (int i = 0; i < coins.Count; i++)
        {
            coins[i].transform.localPosition = localPositions[i];
            coins[i].SetActive(true);
        }
    }

}
