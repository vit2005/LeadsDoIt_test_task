using UnityEngine;
using UnityEngine.UI;

public class BarsController : MonoBehaviour
{
    [SerializeField] private GameObject shieldGameObject;
    [SerializeField] private GameObject magnetGameObject;
    [SerializeField] private GameObject nitroGameObject;

    [SerializeField] private Image healthValue;
    [SerializeField] private Image shieldValue;
    [SerializeField] private Image magnetValue;
    [SerializeField] private Image nitroValue;

    public float SetHealth { set { healthValue.fillAmount = value; } }
    public float SetShield { set { shieldValue.fillAmount = value; } }
    public float SetMagnet { set { magnetValue.fillAmount = value; } }
    public float SetNitro { set { nitroValue.fillAmount = value; } }

    public bool EnableShield { set { shieldGameObject.SetActive(value); } }
    public bool EnableMagnet { set { magnetGameObject.SetActive(value); } }
    public bool EnableNitro { set { nitroGameObject.SetActive(value); } }
}
