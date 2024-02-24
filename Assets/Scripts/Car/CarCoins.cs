using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarCoins : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI cointer;

    private int _coins = 0;
    public int Coins
    {
        get
        {
            return _coins;
        }
        set
        {
            cointer.text = "SCORE:\n" + value;
            _coins = value;
        }
    }
}
