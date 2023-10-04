using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Player _player;
    [SerializeField]
    private Timer _timer;
    [SerializeField]
    private AudioManager _audioManager;
    [SerializeField]
    private GameEndManager _gameEndManager;
    [SerializeField]
    private LevelEndManager _levelEndManager;
    public void LoadNextLevel()
    {
        if (_player.level < 3)
        {
            
            StartCoroutine(DelaySceneLoad());
        }
        else
            _gameEndManager.GameEnd();
    }
    IEnumerator DelaySceneLoad()
    {
        yield return new WaitForSeconds(1f);
        _player.level++;
        _player.currentSpecial = 0;
        _player.UpdateHP(_player.maxHp);
        _player.UpdateSpecial(_player.currentSpecial);
        _player.transform.position = _player.startPos;
        _timer.ResetTimer();
        _audioManager.RestartAudio();
        _levelEndManager.gameObject.SetActive(false);
    }
}
