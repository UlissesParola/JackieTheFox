using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerForeverRun : MonoBehaviour
{
	public float JumpStartForce;
	public float JumpMaxSpeed;
	public float JumpForce;
	public BoxCollider2D GroundCollider;
	public AudioClip JumpAudioClip;
	public AudioClip HittedAudioClip;

	private bool _grounded;
	private bool _jumping;
	private bool _invencible;
	private Rigidbody2D _playerRigidbody2D;
	private BoxCollider2D _playerBoxCollider2D;
	private Animator _playerAnimator;
	private Vector3 _startPosition;
	private PlayerLife _playerLife;
	private float _timer;

	// Use this for initialization
	void Start ()
	{
		_startPosition = transform.position;
		_playerRigidbody2D = GetComponent<Rigidbody2D>();
		_playerBoxCollider2D = GetComponent<BoxCollider2D>();
		_playerAnimator = GetComponent<Animator>();
		_playerLife = GetComponent<PlayerLife>();
		_timer = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		_grounded = _playerBoxCollider2D.IsTouching(GroundCollider);

		if (Input.GetMouseButtonDown(0) && _grounded)
		{
			//_playerRigidbody2D.velocity = new Vector3(0, JumpStartForce, 0);
			Vector2 jumpForce = new Vector2(0, JumpStartForce);
			_playerRigidbody2D.AddForce(jumpForce, ForceMode2D.Impulse);
			_jumping = true;
			AudioSource.PlayClipAtPoint(JumpAudioClip, Camera.main.transform.position);
		}

		if (Input.GetMouseButtonUp(0))
		{
			_jumping = false;
		}

		_playerAnimator.SetFloat("YVelocity", _playerRigidbody2D.velocity.y);
		_playerAnimator.SetBool("Grounded", _grounded);

		if (_invencible)
		{
			InvencibleTime();
		}
	}

	private void FixedUpdate()
	{
		float actualVelocityY = _playerRigidbody2D.velocity.y;
		if (Input.GetMouseButton(0) && _jumping)
		{
			_playerRigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Force);
			if ((actualVelocityY >= JumpMaxSpeed))
			{
				_jumping = false;
			}
		}
	}

	private void InvencibleTime()
	{
		_timer += Time.deltaTime;
		if (_timer >= 1f)
		{
			_invencible = false;
			_timer = 0;
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name.StartsWith("Eagle") && ! _invencible)
		{
			_playerLife.Hitted();
			_playerAnimator.SetTrigger("Hitted");
			AudioSource.PlayClipAtPoint(HittedAudioClip, Camera.main.transform.position);
			_invencible = true;
		}
	}

	public void RestartPlayerPosition()
	{
		transform.position = _startPosition;
		_playerRigidbody2D.velocity = Vector2.zero;
	}
}
