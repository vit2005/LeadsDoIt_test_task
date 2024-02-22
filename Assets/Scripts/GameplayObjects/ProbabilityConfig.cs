using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameplayObjectProbability
{
    public ObjectType type;
    public bool isPositive;
    public int probabilty;
}

//[CreateAssetMenu(menuName = "ProbabilityConfig", fileName = "ProbabilityConfig")]
public class ProbabilityConfig : ScriptableObject
{
    public List<GameplayObjectProbability> probabilities;
}
