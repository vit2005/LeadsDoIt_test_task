using System.Collections;
using TMPro;
using UnityEngine;

public class CountdownGameMode : MonoBehaviour, IGameMode
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private CarMoveController carMove;
    [SerializeField] private CarCoins coins;
    [SerializeField] private CarHP carHp;
    [SerializeField] private CarBuffs buffs;
    [SerializeField] private GameplayObjectPool pool;
    [SerializeField] private EnemyController enemyController;

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
        enemyController.Restart();

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