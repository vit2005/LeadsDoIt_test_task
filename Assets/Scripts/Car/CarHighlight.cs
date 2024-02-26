using UnityEngine;

public class CarHighlight : MonoBehaviour
{
    [SerializeField] private GameObject nitro;
    [SerializeField] private GameObject magnet;
    [SerializeField] private GameObject shield;

    public bool SetNitro
    {
        set
        {
            nitro.SetActive(value);
        }
    }

    public bool SetMagnet
    {
        set
        {
            magnet.SetActive(value);
        }
    }

    public bool SetShield
    {
        set
        {
            shield.SetActive(value);
        }
    }
}
