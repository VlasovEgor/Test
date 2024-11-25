using System;
using UnityEngine;

public class GameStateManager
{
    private static GameStateManager _instance;
    public static GameStateManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameStateManager();
 
            return _instance;
        }
    }

    private GameState CurrentGameState { get; set; }
    
    public event Action<GameState> GameStateChanged;
    
    public void SetState(GameState newGameState)
    {
        if (newGameState == CurrentGameState)
            return;
 
        CurrentGameState = newGameState;
        GameStateChanged?.Invoke(newGameState);
    }
}

public enum GameState
{   
    NONE,
    START,
    PAUSE,
}
