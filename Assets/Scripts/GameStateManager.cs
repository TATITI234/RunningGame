using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance = null;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public GameState currentState;

    public enum GameState
    {
        MainMenu,
        Playing,
        Paused,
        GameOver
    }
    
    // Start is called before the first frame update
    void Start()
    {
        currentState = GameState.Playing;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
