using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultGameMode : MonoBehaviour, IGameMode
{
    [SerializeField] TextMeshProUGUI bestScore;
    [SerializeField] TextMeshProUGUI currentScore;
    [SerializeField] CarCoins coins;
    [SerializeField] SpeedController speedController;
    private int maxScore;

    private const string BEST_SCORE_STRING = "Best score:\n";
    private const string CURRENT_SCORE_STRING = "Your score:\n";
    private const string MAX_SCORE_KEY = "maxScore";

    public void Init()
    {
        gameObject.SetActive(false);
        maxScore = 0;
        if (PlayerPrefs.HasKey(MAX_SCORE_KEY)) maxScore = PlayerPrefs.GetInt(MAX_SCORE_KEY);
    }

    public void OnFinish()
    {
        gameObject.SetActive(false);
    }

    public void OnStart()
    {
        speedController.ForceStop();
        currentScore.text = CURRENT_SCORE_STRING + coins.Score;
        if (coins.Score > maxScore)
        {
            maxScore = coins.Score;
            PlayerPrefs.SetInt(MAX_SCORE_KEY, maxScore);
        }
        bestScore.text = BEST_SCORE_STRING + maxScore;
        gameObject.SetActive(true);
    }

    public void OnRestartButtonClick()
    {
        GameController.Instance.SetGameMode(GameModeId.Countdown);
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
