using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IGameMode
{
    void Init();
    void OnStart();
    void OnFinish();
}
