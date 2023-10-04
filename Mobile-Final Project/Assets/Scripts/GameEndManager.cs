using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndManager : MonoBehaviour
{
    [SerializeField]
    private LevelEndManager _levelEndManager;
    
    public void GameEnd()
    {
        gameObject.SetActive(true);
        _levelEndManager.levelEnd();
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;
        GameState newGameState = currentGameState == GameState.GamePlay
            ? GameState.Pause
            : GameState.GamePlay;
        GameStateManager.Instance.SetState(GameState.Pause);
        AudioListener.pause = true;
        
        SceneManager.LoadScene(0);
    }
    public void PlayerDead()
    {
        _levelEndManager.levelEnd();
        gameObject.SetActive(true);
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;
        GameState newGameState = currentGameState == GameState.GamePlay
            ? GameState.Pause
            : GameState.GamePlay;
        GameStateManager.Instance.SetState(GameState.Pause);
        AudioListener.pause = true;
        
        SceneManager.LoadScene(0);
    }
}
