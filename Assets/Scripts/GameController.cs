using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameModeId 
{
    Countdown,
    Gameplay,
    Result,
    Pause,

}


public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static GameController Instance => _instance;

    [SerializeField] CountdownGameMode countdownGameMode;

    public GameModeId CurrentGameMode = GameModeId.Countdown;

    public void Awake()
    {
        _instance = this;
        SetGameMode(GameModeId.Countdown);
    }

    public void SetGameMode(GameModeId gameModeId)
    {
        CurrentGameMode = gameModeId;
        switch (gameModeId)
        {
            case GameModeId.Countdown:
                StartCoroutine(countdownGameMode.StartGameMode()); 
                break;
            case GameModeId.Gameplay:break; 
            case GameModeId.Result: break; 
            case GameModeId.Pause: break; 
            default: break;
        }
    }
    
    private IEnumerator StartCountdown()
    {

        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(1f);
    } 
}
