using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _youWin;
    [SerializeField]
    private GameObject _youLose;
    [SerializeField]
    private EnemyManager _enemyManager;
    [SerializeField]
    private Player _player;
    
    public void levelEnd()
    {
        gameObject.SetActive(true);
        if (_player.level <= 3)
        {
            if (GetActiveEnemy().currentHp == 0 || _player.currentHp > GetActiveEnemy().currentHp)
            {
                _youWin.SetActive(true);
            }
            else if (_player.currentHp == 0 || _player.currentHp < GetActiveEnemy().currentHp || _player.currentHp == GetActiveEnemy().currentHp)
            {
                _youLose.SetActive(true);
            }
        }
    }
    private Enemy GetActiveEnemy()
    {
        int currentLevel = _player.level;
        return _enemyManager.GetEnemyForLevel(currentLevel);
    }
}
