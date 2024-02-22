using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayObjectController : MonoBehaviour
{
    [SerializeField] List<GameplayObject> negativeObjects = new List<GameplayObject>();
    [SerializeField] List<GameplayObject> positiveObjects = new List<GameplayObject>();

    private GameplayObject _spawnedObject;

    private const float SPEED_MULTIPLIER = 0.01f;

    private Action<GameplayObjectController> _release;
    public bool isRightSide;
    public bool isPositive;

    public void Init(Action<GameplayObjectController> release)
    {
        _release = release;
        foreach (GameplayObject obj in negativeObjects) { obj.gameObject.SetActive(false); };
        foreach (GameplayObject obj in positiveObjects) { obj.gameObject.SetActive(false); };
    }

    public void Enable()
    {
        _spawnedObject = isPositive ? positiveObjects[UnityEngine.Random.Range(0, positiveObjects.Count)] :
            negativeObjects[UnityEngine.Random.Range(0, negativeObjects.Count)];
        _spawnedObject.Init();
    }

    public void Update()
    {
        transform.position -= Vector3.up * SpeedController.speed * SPEED_MULTIPLIER * Time.deltaTime;
        if (transform.position.y < -1f)
        {
            _release.Invoke(this);
        }
    }

    public void Clear()
    {
        _spawnedObject?.Clear();
    }
}
