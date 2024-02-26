using UnityEngine;
using UnityEngine.Pool;

public class BushObjectPool : MonoBehaviour
{
    [SerializeField] Transform bushPrefab;
    [SerializeField] Transform parent;
    [SerializeField] Transform left;
    [SerializeField] Transform right;

    public IObjectPool<Bush> pool;
    public bool spawns = false;

    private Vector3 _rightPos;
    private Vector3 _leftPos;

    private const float SPAWN_TIME = 500f;
    private float _nextSpawnTime = 0f;
    private float _currentTime = 0f;
    private bool? _spawnRightSide = null;

    // Start is called before the first frame update
    void Start()
    {
        _rightPos = right.position;
        _leftPos = left.position;
        pool = new ObjectPool<Bush>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, 5, 10);
        CalculateNextSpawnTime();
    }

    private void CalculateNextSpawnTime()
    {
        _nextSpawnTime += SPAWN_TIME + UnityEngine.Random.Range(-2f, 2f);
    }

    private Bush CreatePooledItem()
    {
        var bush = Instantiate(bushPrefab, parent).GetComponent<Bush>();
        bush.Init((Bush b) => { pool.Release(b); });
        bush.gameObject.SetActive(false);
        return bush;
    }

    private void OnTakeFromPool(Bush item)
    {
        bool isRightSide = _spawnRightSide.HasValue ? _spawnRightSide.Value : UnityEngine.Random.Range(0, 2) == 0;
        _spawnRightSide = null;
        Vector3 pos = isRightSide ? _rightPos : _leftPos;
        item.isRightSide = isRightSide;
        item.transform.position = pos;
        item.transform.Rotate(0f, 0f, UnityEngine.Random.Range(0f, 360f));
        item.transform.localScale = Vector3.one * UnityEngine.Random.Range(1.8f, 2.2f);
        item.gameObject.SetActive(true);
    }

    private void OnReturnedToPool(Bush item)
    {
        item.gameObject.SetActive(false);
    }

    private void OnDestroyPoolObject(Bush item)
    {
        GameObject.Destroy(item.gameObject);
    }

    void Update()
    {
        _currentTime += Time.deltaTime * SpeedController.speed;
        if (_currentTime > _nextSpawnTime)
        {
            CalculateNextSpawnTime();
            var bush = pool.Get();
            if (UnityEngine.Random.Range(0, 2) == 0)
            {
                _spawnRightSide = !bush.isRightSide;
                pool.Get();
            }
        }
    }
}
