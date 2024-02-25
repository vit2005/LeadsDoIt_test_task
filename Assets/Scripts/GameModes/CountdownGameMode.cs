using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownGameMode : MonoBehaviour, IGameMode
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] CarMoveController carMove;
    [SerializeField] CarCoins coins;
    [SerializeField] CarHP carHp;
    [SerializeField] CarBuffs buffs;
    [SerializeField] GameplayObjectPool pool;

    public void Init()
    {
        carMove.Init();
    }

    public void OnFinish()
    {
        
    }

    public void OnStart()
    {
        coins.Score = 0;
        carHp.HP = 100;
        carMove.Restart();
        buffs.VanishAll();
        pool.Clear();

        StartCoroutine(StartGameMode());
    }

    public IEnumerator StartGameMode()
    {
        text.text = "";
        yield return new WaitForSeconds(1);
        text.text = "3";
        yield return new WaitForSeconds(1);
        text.text = "2";
        yield return new WaitForSeconds(1);
        text.text = "1";
        yield return new WaitForSeconds(1);
        text.text = "START";
        GameController.Instance.SetGameMode(GameModeId.Gameplay);
        yield return new WaitForSeconds(1);
        text.text = "";
    }
}
