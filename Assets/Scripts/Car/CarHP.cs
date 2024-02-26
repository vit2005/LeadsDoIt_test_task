using UnityEngine;

public class CarHP : MonoBehaviour, IUpdatable
{
    public bool isDamaging = false;
    public bool isShielded = false;

    private const float DAMAGE_TICK_DAMAGE = 0.05f;
    private const float DAMAGE_TICK_DURATION = 1f;

    private float _hp = 1;
    private float _lastDamageTime = 0;

    [SerializeField] private BarsController barsController;

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
            _hp = value;
            if (_hp == 0f) GameController.Instance.SetGameMode(GameModeId.Result);
        }
    }

    public void OnUpdate()
    {
        if (isDamaging && !isShielded)
        {
            if (_lastDamageTime < Time.time - DAMAGE_TICK_DURATION)
            {
                HP -= DAMAGE_TICK_DAMAGE;
                _lastDamageTime = Time.time;
            }
        }
    }
}