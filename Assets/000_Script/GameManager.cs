using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private Enum.GameState currentGameState;

    public UnityEvent<Enum.GameState> onStateChange;

    public Enum.GameState CurrentGameState { get => currentGameState; private set { } }

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
        currentGameState = Enum.GameState.Hall;
        
    }
    private void Start()
    {
        onStateChange?.Invoke(currentGameState);
    }
    public void SetGameState(Enum.GameState gameState)
    {
        this.currentGameState = gameState;
        onStateChange?.Invoke(this.currentGameState);  
    }



}
