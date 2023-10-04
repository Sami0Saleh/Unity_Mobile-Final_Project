using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fightmanager : MonoBehaviour
{
    [SerializeField]
    private EnemyManager _enemyManager;
    [SerializeField]
    private Player _player;
    void Update()
    {
        if (_player.level <= 3)
        {
            if (_player.punchHit)
            {
                _player.PlayerPunch(_player, GetActiveEnemy());
                GetActiveEnemy().UpdateHP(GetActiveEnemy().currentHp);
                _player.UpdateSpecial(_player.currentSpecial);
                _player.punchHit = false;
            }
            if (_player.specialAttackHit)
            {
                _player.PlayerSpecialAttack(_player, GetActiveEnemy());
                GetActiveEnemy().UpdateHP(GetActiveEnemy().currentHp);
                _player.specialAttackHit = false;
            }
            if (GetActiveEnemy().attackHit)
            {
                GetActiveEnemy().EnemyAttack(GetActiveEnemy(), _player);
                _player.UpdateHP(_player.currentHp);
                GetActiveEnemy().UpdateSpecial(GetActiveEnemy().currentSpecial);
                GetActiveEnemy().attackHit = false;
            }
            if (GetActiveEnemy().specialAttackHit)
            {
                GetActiveEnemy().EnemySpecialAttack(GetActiveEnemy(), _player);
                _player.UpdateHP(_player.currentHp);
                GetActiveEnemy().specialAttackHit = false;
            }
        }
    }
    private Enemy GetActiveEnemy()
    {
        int currentLevel = _player.level;
        return _enemyManager.GetEnemyForLevel(currentLevel);
    }
}
