using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	[SerializeField]
	private PlayerController _playerController;
	[SerializeField]
	private HealthBar _healthBar;
	[SerializeField]
	private GameEndManager _gameEndManager;
	[SerializeField]
	private SpecialAttackBar _specialAttackBar;
	[SerializeField]
	private Button _specialAttackButton;

	public bool isPlayerDead = false;
	public int currentHp = 100;
	public int maxHp = 100;
	public int punch = 1;
	public int specialAttack = 8;
	public int currentSpecial = 0;
	public bool punchHit = false;
	public bool specialAttackHit = false;
	public int level = 1;
	public Vector2 startPos;
	private void Start()
    {
		startPos = transform.position;
	}
    private void Update()
    {
        if (isPlayerDead)
        {
			_playerController.DeathAnimation();
			_gameEndManager.PlayerDead();
		}
		if (currentSpecial < 5)
			_specialAttackButton.gameObject.SetActive(false);
		else if (currentSpecial >= 5)
			_specialAttackButton.gameObject.SetActive(true);
	}
    private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy") && _playerController.playerPunch)
		{
			punchHit = true;
		}
		else if (collision.gameObject.CompareTag("Enemy") && _playerController.playerspecialAttack)
		{
			specialAttackHit = true;
		}
	}
	public void UpdateHP(int newCurrentHP)
	{
		currentHp = newCurrentHP;
		_healthBar.UpdateHealthBar(currentHp);
	}
	public int PlayerPunch(Player player, Enemy enemy)
	{
		enemy.currentHp = enemy.currentHp - player.punch;
		player.currentSpecial++;
		if (enemy.currentHp < 0)
			enemy.currentHp = 0;
		return enemy.currentHp;
	}
	public int PlayerSpecialAttack(Player player, Enemy enemy)
	{
		enemy.currentHp = enemy.currentHp - player.specialAttack;
		if (enemy.currentHp < 0)
			enemy.currentHp = 0;
		return enemy.currentHp;
	}
	public void UpdateSpecial(int newCurrentSpecial)
	{
		currentSpecial = newCurrentSpecial;
		_specialAttackBar.UpdateSpecialBar(currentSpecial);
	}
}
