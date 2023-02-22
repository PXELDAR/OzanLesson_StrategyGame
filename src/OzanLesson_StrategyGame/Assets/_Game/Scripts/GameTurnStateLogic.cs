using System;
using UnityEngine;

public class GameTurnStateLogic : MonoBehaviour
{
    public static GameTurnStateLogic Instance { get; private set; }
    
    public delegate void OnGameTurnStateChange(GameTurnState newState);
    public event OnGameTurnStateChange onGameTurnStateChange;
    
    public void OnGameTurnStateChanged(GameTurnState newState)
    {
        onGameTurnStateChange?.Invoke(newState);
    }

    private void Awake()
    {
        Instance = this;
    }

    public enum GameTurnState
    {
        PlayerTurn,
        EnemyTurn,
        TransitionTurn
    };

    public GameTurnState _currentGameTurnState;

    private void Start()
    {
       ChangeState(GameTurnState.PlayerTurn); 
    }

    public void ChangeState(GameTurnState newState)
    {
        _currentGameTurnState = newState;
        OnGameTurnStateChanged(newState);
    }

    public GameTurnState GetCurrentGameTurnState()
    {
        return _currentGameTurnState;
    }
}