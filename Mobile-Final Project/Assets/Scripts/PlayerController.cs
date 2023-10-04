using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private Player _player;
	[SerializeField]
	private Animator _animator;
	[SerializeField]
	private PauseMenu _pauseMenu;
	[SerializeField]
	private float _walkSpeed;
	[SerializeField]
	private float _jumpForce;
	private bool _moveLeft;
	private bool _dontMove;
	private bool _canJump;
	private Rigidbody2D _playerRb;
	
	public bool playerPunch = false;
	public bool playerspecialAttack = false;
    private void Awake()
    {
		GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
		_playerRb = GetComponent<Rigidbody2D>();
		_dontMove = true;
	}
    private void OnDestroy()
    {
		GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
	}
    private void Update()
    {
		HandelMoving();
		if (Input.touchCount >= 2)
		{

			_pauseMenu.PauseGame();
		}
	}
	private void HandelMoving()
    {
		if (_dontMove)
        {
			StopMovement();
        }
        else
        {
			if (_moveLeft)
            {
				MoveLeft();
            }
			else if (!_moveLeft)
            {
				MoveRight();
            }
        }
    }
	public void AllowMoveing(bool movement)
    {
		_dontMove = false;
		_moveLeft = movement;
    }
	public void DontAllowMoveing()
	{
		_dontMove = true;
	}
	public void StopMovement()
	{
		_playerRb.velocity = new Vector2(0f, _playerRb.velocity.y);
	}
	public void MoveRight()
	{
		_playerRb.velocity = new Vector2(_walkSpeed, _playerRb.velocity.y);
		_animator.Play("RightWalk");
		playerPunch = false;
		playerspecialAttack = false;
	}
	public void MoveLeft()
	{
		_playerRb.velocity = new Vector2(-_walkSpeed, _playerRb.velocity.y);
		_animator.Play("LeftWalk");
		playerPunch = false;
		playerspecialAttack = false;
	}
	public void Jump()
    {
		if (_canJump)
        {
			_playerRb.velocity = new Vector2(_playerRb.velocity.x, _jumpForce);
			_animator.Play("Jump");
		}
	}
	public void PunchAnimation()
	{
		_animator.Play("Punch");
		playerPunch = true;
		playerspecialAttack = false;
	}
	public void SpecialAttackAnimation()
	{
		
		_animator.Play("SpecialAttack");
		_player.currentSpecial = 0;
		_player.UpdateSpecial(_player.currentSpecial);
		playerspecialAttack = true;
		playerPunch = false;
	}
	public void DeathAnimation()
    {
		_animator.Play("Death");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
			_canJump = true;
        }
    }
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			_canJump = false;
		}
	}
	private void OnGameStateChanged(GameState newGameState)
	{
		enabled = newGameState == GameState.GamePlay;
		if (newGameState == GameState.GamePlay)
			_animator.speed = 1;
        else
        {
			_animator.speed = 0;
			StopMovement();
		}
	}
}
