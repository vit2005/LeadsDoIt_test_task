using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GameplayObjectPool : MonoBehaviour
{
    [SerializeField] Transform GameplayObjectControllerPrefab;
    [SerializeField] Transform parent;
    [SerializeField] Transform left;
    [SerializeField] Transform right;

    public IObjectPool<GameplayObjectController> pool;
    public bool spawns = false;

    private Vector3 _rightPos;
    private Vector3 _leftPos;

    private const float SPAWN_TIME = 800f;
    private float _nextSpawnTime = 0f;
    private float _currentTime = 0f;
    private bool? _spawnRightSide = null;
    private bool? _spawnPositive = null;

    private const int positiveProbability = 60;

    // Start is called before the first frame update
    void Start()
    {
        _rightPos = right.position;
        _leftPos = left.position;
        pool = new ObjectPool<GameplayObjectController>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, 5, 10);
        CalculateNextSpawnTime();
    }

    private void CalculateNextSpawnTime()
    {
        _nextSpawnTime += SPAWN_TIME + UnityEngine.Random.Range(-200f, 200f);
    }

    private GameplayObjectController CreatePooledItem()
    {
        var gameplayObject = Instantiate(GameplayObjectControllerPrefab, parent).GetComponent<GameplayObjectController>();
        gameplayObject.Init((GameplayObjectController b) => { pool.Release(b); });
        gameplayObject.gameObject.SetActive(false);
        return gameplayObject;
    }

    private void OnTakeFromPool(GameplayObjectController item)
    {
        bool isRightSide = _spawnRightSide.HasValue ? _spawnRightSide.Value : UnityEngine.Random.Range(0, 2) == 0;
        Vector3 pos = isRightSide ? _rightPos : _leftPos;
        item.isRightSide = isRightSide;
        item.transform.position = pos;
        if (_spawnRightSide.HasValue) item.transform.position += Vector3.up * UnityEngine.Random.Range(1f, 5f);
        _spawnRightSide = null;

        bool isPositive = _spawnPositive.HasValue ? _spawnPositive.Value : UnityEngine.Random.Range(0, 100) < positiveProbability;
        item.isPositive = isPositive;
        item.Enable();
        _spawnPositive = null;

        //item.transform.Rotate(0f, 0f, UnityEngine.Random.Range(0f, 360f));
        //item.transform.localScale = Vector3.one * UnityEngine.Random.Range(1.8f, 2.2f);
        item.gameObject.SetActive(true);
    }

    private void OnReturnedToPool(GameplayObjectController item)
    {
        item.Clear();
        item.gameObject.SetActive(false);
    }

    private void OnDestroyPoolObject(GameplayObjectController item)
    {
        GameObject.Destroy(item.gameObject);
    }

    void Update()
    {
        _currentTime += Time.deltaTime * SpeedController.speed;
        if (_currentTime > _nextSpawnTime)
        {
            CalculateNextSpawnTime();
            var gameplayObject = pool.Get();
            if (gameplayObject.isPositive && UnityEngine.Random.Range(0, 2) == 0)
            {
                _spawnRightSide = !gameplayObject.isRightSide;
                pool.Get();
            }
        }

    }
}
