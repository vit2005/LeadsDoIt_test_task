using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMagnet : MonoBehaviour
{
    public virtual void OnTriggerStay2D(Collider2D collision)
    {
        var coin = collision.GetComponent<CoinGameplayObject>();
        if (coin == null) return;
        coin.GetComponent<Rigidbody2D>().AddForce((transform.position - coin.transform.position) * 120f);
    }
}
