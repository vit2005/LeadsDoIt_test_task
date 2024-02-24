using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHP : MonoBehaviour
{
    private float _hp = 1;
    public float HP
    {
        get
        {
            return _hp;
        }
        set
        {
            value = Mathf.Clamp01(value);
            barsController.SetHealth = value;
        }
    }

    [SerializeField] private BarsController barsController;

    public bool isShielded = false;
    public bool isDamaging = false;
    private float lastDamageTime = 0;
    private const float DAMAGE_TICK_DURATION = 1f;
    private const float DAMAGE_TICK_DAMAGE = 0.05f;

    public void Update()
    {
        barsController.SetHealth = _hp;

        if (isDamaging && !isShielded)
        {
            if (lastDamageTime < Time.time - DAMAGE_TICK_DURATION)
            {
                _hp -= DAMAGE_TICK_DAMAGE;
                lastDamageTime = Time.time;
            }
        }
    }
}
