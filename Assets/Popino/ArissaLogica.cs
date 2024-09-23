using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArissaLogica : MonoBehaviour
{
	Animator _anim;
	bool _onGround;
	float _horizontal;
	public bool talk=false;
	bool jump = false;
	void Start()
	{
		_anim = gameObject.GetComponentInChildren<Animator>();
	}

	void Update()
	{
		jump = false;
		if (Input.GetKeyDown(KeyCode.Space))
		{
			jump = true;
		}
		_horizontal = Input.GetAxis("Vertical");
//		_anim.SetFloat("Cammino", _horizontal);
		_anim.SetBool("Jump", jump);
		if (Input.GetKeyDown(KeyCode.L))
		{
			_anim.SetBool("Ballo", true);
		}
		if (Input.GetKeyUp(KeyCode.L))
		{
			_anim.SetBool("Ballo", false);
		}
		_anim.SetBool("talk", talk);
	}
	public void allinea()
	{
		GetComponentInParent<CharacterController>().Move(transform.forward * 3f);
	}
}
