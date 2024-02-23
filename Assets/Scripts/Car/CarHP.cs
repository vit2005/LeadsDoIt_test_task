using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHP : MonoBehaviour
{
    private static CarHP _instance;
    public static CarHP Instance => _instance;

    public void Awake()
    {
        _instance = this;
    }
}
