using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private List<Enemy> _enemies;
    public Enemy GetEnemyForLevel(int level)
    {
        if (level >= 1 && level <= _enemies.Count)
        {
            return _enemies[level - 1];
        }

        return null;
    }
}
