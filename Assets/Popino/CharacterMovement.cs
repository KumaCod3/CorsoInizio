using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
	Animator _anim;
	CharacterController _cc;
	Vector2 _moveInput;
	float _speed = 1.1f;
	public InputManager _inputM;
	bool _isCrouch;
	bool _isJumping;
	float tp = 0;

	void Start()
	{
		_anim = GetComponentInChildren<Animator>();
		_cc = GetComponent<CharacterController>();
	}

	void Update()
	{
		Locom();
		Crouch(_inputM.crouch);
		Jump(_inputM.jump);
		Run(_inputM.running);
	}

	private void Jump(KeyCode jump)
	{
		if (Input.GetKeyDown(jump))
		{
			_anim.SetBool("Jump", true);
		}
		if (!Input.GetKey(jump))
		{
			_anim.SetBool("Jump", false);
		}
	}

	private void Crouch(KeyCode crouch)
	{
		if (Input.GetKey(crouch))
		{
			tp = Mathf.Lerp(tp, -5, 0.05f);
		}
		if (!Input.GetKey(crouch))
		{
			tp = Mathf.Lerp(tp, 0, 0.05f);
		}
		_anim.SetFloat("cuccia", tp);
	}
	private void Run(KeyCode Run)
	{
		if (Input.GetKey(Run))
		{
			_speed = Mathf.Lerp(_speed, 5, 0.05f);
		}
		if (!Input.GetKey(Run))
		{
			_speed = Mathf.Lerp(_speed, 1.1f, 0.05f);
		}
	}
	private void Locom()
	{
		_moveInput.x = Input.GetAxis("Horizontal") * 3;
		_moveInput.y = Input.GetAxis("Vertical")* _speed ;
		_anim.SetFloat("InputY", _moveInput.y);
		Vector3 speedCharacter = transform.forward * _moveInput.y;
		speedCharacter.y -= 20f ;
		_cc.Move(speedCharacter * Time.fixedDeltaTime);
		gameObject.transform.Rotate(new Vector3(0, _moveInput.x*0.6f, 0));
		
	}
	public void allinea()
	{
	//	_cc.Move(transform.forward * 3f);
	}
}
