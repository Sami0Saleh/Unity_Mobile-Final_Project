using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private GameEndManager _gameEndManager;
    [SerializeField]
    private LevelEndManager _levelEndManager;
    private float _currentTime;

    public Text timerText;
    public int initialTime = 40;
    private void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }
    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }
    private void Start()
    {
        _currentTime = initialTime;
        UpdateTimerDisplay();
    }
    private void Update()
    {
        if (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        
        if (_currentTime <= 0)
        {
            Debug.Log("ended");
            _gameEndManager.GameEnd();
        }
    }
    private void UpdateTimerDisplay()
    {
        int seconds = Mathf.CeilToInt(_currentTime);
        timerText.text = seconds.ToString();
    }
    private void OnGameStateChanged(GameState newGameState)
    {
        enabled = newGameState == GameState.GamePlay;
    }
    public void ResetTimer()
    {
        _currentTime = initialTime;
    }
}
