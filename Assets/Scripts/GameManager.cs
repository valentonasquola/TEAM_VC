using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState
    {
        Loading,
        MainMenu,
        Gameplay,
        GameOver
    }

    private void Start()
    {
        SetGameState(GameState.MainMenu);
    }
    public GameState CurrentState { get; private set; }
    public void SetGameState(GameState newState)
    {
        CurrentState = newState;

    }
}