using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGameplayObject : MonoBehaviour
{
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        var coins = collision.GetComponent<CarCoins>();
        if (coins == null) return;
        coins.Score += 10;
        gameObject.SetActive(false);
    }
}
