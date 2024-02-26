using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameplayObjectController : MonoBehaviour
{
    public bool isPositive;
    public bool isRightSide;

    private const float SPEED_MULTIPLIER = 0.01f;

    private Action<GameplayObjectController> _release;
    private GameplayObject _spawnedObject;
    private int maxNegative;
    private int maxPositive;

    [SerializeField] private List<GameplayObject> negativeObjects = new List<GameplayObject>();
    [SerializeField] private List<GameplayObject> positiveObjects = new List<GameplayObject>();
    [SerializeField] private ProbabilityConfig probabilityConfig;

    public void Clear()
    {
        _spawnedObject?.Clear();
    }

    public void Enable()
    {
        SetSpawnedObject(GetObjectType());
    }

    public void Init(Action<GameplayObjectController> release)
    {
        _release = release;

        foreach (var prob in probabilityConfig.probabilities)
        {
            if (prob.isPositive) maxPositive += prob.probabilty;
            else maxNegative += prob.probabilty;
        }

        foreach (GameplayObject obj in negativeObjects) { obj.gameObject.SetActive(false); };
        foreach (GameplayObject obj in positiveObjects) { obj.gameObject.SetActive(false); };
    }

    public void Update()
    {
        transform.position -= Vector3.up * SpeedController.speed * SPEED_MULTIPLIER * Time.deltaTime;
        if (transform.position.y < -1f)
        {
            _release.Invoke(this);
        }
    }

    private ObjectType GetObjectType()
    {
        ObjectType? objectType = null;
        int prob = 0;
        if (isPositive)
        {
            int i = UnityEngine.Random.Range(0, maxPositive);
            IEnumerable<GameplayObjectProbability> objects = probabilityConfig.probabilities.Where(x => x.isPositive);
            foreach (var item in objects)
            {
                if (i < item.probabilty + prob)
                {
                    objectType = item.type; break;
                }
                else
                {
                    prob += item.probabilty;
                }
            }
            if (!objectType.HasValue) objectType = objects.Last().type;
        }
        else
        {
            int i = UnityEngine.Random.Range(0, maxNegative);
            IEnumerable<GameplayObjectProbability> objects = probabilityConfig.probabilities.Where(x => !x.isPositive);
            foreach (var item in objects)
            {
                if (i < item.probabilty + prob)
                {
                    objectType = item.type; break;
                }
                else
                {
                    prob += item.probabilty;
                }
            }
            if (!objectType.HasValue) objectType = objects.Last().type;
        }
        return objectType.Value;
    }

    private void SetSpawnedObject(ObjectType objectType)
    {
        var list = isPositive ? positiveObjects.Where(x => x.objectType == objectType).ToList() :
            negativeObjects.Where(x => x.objectType == objectType).ToList();
        //Debug.Log(objectType.ToString() + "   " + isPositive + "   " + list.Count);
        _spawnedObject = list[UnityEngine.Random.Range(0, list.Count)];
        _spawnedObject.Init();
    }
}