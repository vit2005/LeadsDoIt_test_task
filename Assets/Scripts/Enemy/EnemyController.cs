using UnityEngine;

public class EnemyController : MonoBehaviour, IUpdatable
{
    [SerializeField] private CarMoveController carMoveController;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject chasingIndicator;

    private Vector3 _initialPosition;
    private float _currentWaitingTime;
    private ChasingPhase _phase = ChasingPhase.Waiting;

    private const float WAITING_TIME = 60f;
    private const float SPEED_TO_RELEASE = 800f;
    private const float HIT_DAMAGE = 0.15f;

    private enum ChasingPhase
    {
        Waiting,
        InitialHit,
        Releasing,
        Chacing
    }

    public void Init()
    {
        _initialPosition = transform.position;
        chasingIndicator.SetActive(false);
    }

    public void OnUpdate()
    {
        Debug.Log(_phase);
        Vector3 dirToInitial = _initialPosition - transform.position;
        Vector3 dirToTarget = carMoveController.transform.position - transform.position;
        switch (_phase)
        {
            case ChasingPhase.Waiting:
                if (dirToInitial.y < 0) rb.AddForce(dirToInitial);
                else rb.velocity = Vector3.zero;

                _currentWaitingTime += Time.deltaTime;
                if (_currentWaitingTime > WAITING_TIME)
                {
                    transform.position = new Vector2(carMoveController.transform.position.x, transform.position.y);
                    rb.velocity = Vector2.zero;
                    _phase = ChasingPhase.InitialHit;
                    _currentWaitingTime = 0;
                }
                break;

            case ChasingPhase.InitialHit:
                rb.AddForce(dirToTarget);
                break;

            case ChasingPhase.Releasing:
                if (dirToTarget.magnitude > 2f) _phase = ChasingPhase.Chacing;
                else rb.AddForce(dirToInitial * 0.1f);
                break;

            case ChasingPhase.Chacing:
                rb.AddForce(dirToTarget * (1000f - SpeedController.speed) / 1000f);
                break;
        }

        if ((_phase == ChasingPhase.Chacing || _phase == ChasingPhase.Releasing) && SpeedController.speed > SPEED_TO_RELEASE) _phase = ChasingPhase.Waiting;
        if (transform.position.y > carMoveController.transform.position.y)
        {
            rb.velocity = Vector2.zero;
            _phase = ChasingPhase.Releasing;
        }

        chasingIndicator.SetActive(_phase != ChasingPhase.Waiting);
    }

    public void Restart()
    {
        transform.position = _initialPosition;
        rb.velocity = Vector2.zero;
        _currentWaitingTime = 0;
        _phase = ChasingPhase.Waiting;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        CarBuffs buffs = collision.GetComponent<CarBuffs>();
        if (buffs != null)
        {
            buffs.ApplyBuff(BuffId.Slow);
            collision.GetComponent<CarHP>().HP -= HIT_DAMAGE;
            if (_phase == ChasingPhase.InitialHit || _phase == ChasingPhase.Chacing) _phase = ChasingPhase.Releasing;
            rb.velocity = Vector2.zero;
        }
    }
}