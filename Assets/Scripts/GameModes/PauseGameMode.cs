using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPauseHandler
{
    void Pause();
    void UnPause();
}

public class PauseGameMode : MonoBehaviour, IGameMode
{
    [SerializeField] CarBuffs buffs;
    [SerializeField] SpeedController speedController;

    public void Init()
    {
        gameObject.SetActive(false);
    }

    public void OnPauseButtonClick()
    {
        if (GameController.Instance.CurrentGameMode != GameModeId.Gameplay) return;
        GameController.Instance.SetGameMode(GameModeId.Pause);
    }

    public void OnRestartButtonClick()
    {
        GameController.Instance.SetGameMode(GameModeId.Countdown);
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    public void OnCloseButtonClick()
    {
        GameController.Instance.SetGameMode(GameModeId.Gameplay);
    }

    public void OnFinish()
    {
        speedController.UnPause();
        gameObject.SetActive(false);
    }

    public void OnStart()
    {
        speedController.Pause();
        gameObject.SetActive(true);
    }
}
