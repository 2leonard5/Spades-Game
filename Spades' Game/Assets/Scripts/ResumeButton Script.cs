using UnityEngine;

public class ResumeButtonScript : MonoBehaviour
{
    public void ResumeGame()
    {
        if(GameStateManager.Instance.CurrentGameState == GameState.Paused)
        GameStateManager.Instance.SetState(GameState.Gameplay);
    }
}
