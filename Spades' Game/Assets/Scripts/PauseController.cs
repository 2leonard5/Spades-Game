using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PauseController : MonoBehaviour {
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GameState currentGameState = GameStateManager.Instance.CurrentGameState;
            GameState newGameState = currentGameState == GameState.Gameplay
                ? GameState.Paused : GameState.Gameplay;

            GameStateManager.Instance.SetState(newGameState);
        }
    }
}
