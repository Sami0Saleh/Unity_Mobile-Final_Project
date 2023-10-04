using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _pauseText;
    [SerializeField]
    private Transform _pauseTextTra;
    [SerializeField]
    private float _tweenTime;
    void Start()
    {
        this.gameObject.SetActive(false);
    }
    private void OnApplicationPause(bool pause)
    {
        PauseGame();
    }
    private void OnApplicationFocus(bool focus)
    {
        ContinueGame();
    }
    public void PauseGame()
    {
        this.gameObject.SetActive(true);
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;
        GameState newGameState = currentGameState == GameState.GamePlay
            ? GameState.Pause
            : GameState.GamePlay;
        GameStateManager.Instance.SetState(newGameState);
        AudioListener.pause = true;
        Tween();
    }
    public void ContinueGame()
    {
        this.gameObject.SetActive(false);
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;
        GameState newGameState = currentGameState == GameState.GamePlay
            ? GameState.Pause
            : GameState.GamePlay;
        GameStateManager.Instance.SetState(newGameState);
        AudioListener.pause = false;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Tween()
    {
        _pauseText.DOColor(Color.green, _tweenTime);
        _pauseTextTra.DOShakeRotation(_tweenTime, 30, 10, 70, true, ShakeRandomnessMode.Full);
        _pauseTextTra.DOScale(2, _tweenTime);
    }
}
