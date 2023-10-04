using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private HealthBar _healthBar;
    [SerializeField]
    private Player _player;
    [SerializeField]
    private Transform _playerPos;
    [SerializeField]
    private LevelManager _levelManager;
    [SerializeField]
    private LevelEndManager _levelEndManager;
    [SerializeField]
    private SpecialAttackBar _specialAttackBar;

    public int currentHp = 100;
    public int maxHp = 100;
    public float movmentSpeed = 1;
    public int attack = 2;
    public int specialAttack = 8;
    public int currentSpecial = 0;
    public bool enemyAttack = false;
    public bool enemySpecialAttack = false;
    public bool attackHit = false;
    public bool specialAttackHit = false;
    public bool enemySpecialAttackAnimation = false;
    private void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }
    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }
    void Update()
    {
        float distance = Vector2.Distance(_playerPos.transform.position, this.transform.position);
        if (distance > 2f)
        {
            EnemyMove();
        }
        else if (distance <= 2f)
        {
            if (currentSpecial > 5 && !enemySpecialAttackAnimation)
                AttackAnimation();
            else if (currentSpecial == 5)
            {
                SpecialAttackAnimation();
                enemySpecialAttackAnimation = false;
            }
        }
        if (currentHp <= 0)
        {
            _levelEndManager.levelEnd();
            FallAnimation();
            StartCoroutine(DelayEnemyLoad());
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && enemyAttack)
        {
            attackHit = true;
        }
        else if (collision.gameObject.CompareTag("Player") && enemySpecialAttack)
        {
            specialAttackHit = true;
        }
    }
    public void EnemyMove()
    {
        _animator.Play("Walk");
        transform.Translate(Vector2.left * movmentSpeed * Time.deltaTime);
        enemyAttack = false;
    }
    public bool AttackAnimation()
    {
        _animator.Play("Attack");
        enemyAttack = true;
        return true;
    }
    public bool SpecialAttackAnimation()
    {
        enemySpecialAttackAnimation = true;
        _animator.Play("SpecialAttack");
        enemySpecialAttack = true;
        currentSpecial = 0;
        UpdateSpecial(currentSpecial);
        return true;
    }
    public bool FallAnimation()
    {
        _animator.Play("Death");
        return true;
    }
    public void UpdateHP(int newCurrentHP)
    {
        currentHp = newCurrentHP;
        _healthBar.UpdateHealthBar(currentHp);
    }
    public int EnemyAttack(Enemy enemy, Player player)
    {
        player.currentHp = player.currentHp - enemy.attack;
        enemy.currentSpecial++;
        if (player.currentHp < 0)
        {
            player.currentHp = 0;
            player.isPlayerDead = true;
        }
        return player.currentHp;
    }
    public int EnemySpecialAttack(Enemy enemy, Player player)
    {
        player.currentHp =- enemy.specialAttack;
        if (player.currentHp < 0)
        {
            player.currentHp = 0;
            player.isPlayerDead = true;
        }
        return player.currentHp;
    }
    public void UpdateSpecial(int newCurrentSpecial)
    {
        currentSpecial = newCurrentSpecial;
        _specialAttackBar.UpdateSpecialBar(currentSpecial);
    }
    private void OnGameStateChanged(GameState newGameState)
    {
        enabled = newGameState == GameState.GamePlay;
        if (newGameState == GameState.GamePlay)
            _animator.speed = 1;
        else
            _animator.speed = 0;
    }
    IEnumerator DelayEnemyLoad()
    {
        yield return new WaitForSeconds(1f);
        _levelManager.LoadNextLevel();
        if (_player.level <= 3)
        {
            currentHp = maxHp;
            currentSpecial = 0;
            UpdateHP(currentHp);
            UpdateSpecial(currentSpecial);
        }
        
    }
}
