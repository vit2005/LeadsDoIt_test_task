using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpdatable
{
    void OnUpdate();
}

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
    [SerializeField] GameplayGameMode gameplayGameMode;
    [SerializeField] PauseGameMode pauseGameMode;
    [SerializeField] ResultGameMode resultGameMode;

    [SerializeField] SpeedController speedController;
    [SerializeField] CarMoveController carMoveController;
    [SerializeField] CarBuffs carBuffs;
    [SerializeField] CarHP carHP;
    [SerializeField] GameplayObjectPool pool;
    public SpeedController SpeedController => speedController;

    private GameModeId _currentGameMode = GameModeId.Countdown;
    public GameModeId CurrentGameMode => _currentGameMode;

    private Dictionary<GameModeId, IGameMode> _gameModes = new Dictionary<GameModeId, IGameMode>();
    private List<IUpdatable> _gameplayUpdatables = new List<IUpdatable>();

    public void Awake()
    {
        _instance = this;
        _gameModes.Add(GameModeId.Countdown, countdownGameMode);
        _gameModes.Add(GameModeId.Gameplay, gameplayGameMode);
        _gameModes.Add(GameModeId.Pause, pauseGameMode);
        _gameModes.Add(GameModeId.Result, resultGameMode);

        foreach (var mode in _gameModes.Values)
        {
            mode.Init();
        }

        carBuffs.Init();
        pool.Init();

        _gameplayUpdatables.Add(speedController);
        _gameplayUpdatables.Add(carMoveController);
        _gameplayUpdatables.Add(carBuffs);
        _gameplayUpdatables.Add(carHP);

        SetGameMode(GameModeId.Countdown);
    }

    public void SetGameMode(GameModeId gameModeId)
    {
        _gameModes[_currentGameMode].OnFinish();
        _currentGameMode = gameModeId;
        _gameModes[_currentGameMode].OnStart();
    }

    public void Update()
    {
        if (_currentGameMode != GameModeId.Gameplay) return;

        foreach (var item in _gameplayUpdatables)
        {
            item.OnUpdate();
        }
    }
}
