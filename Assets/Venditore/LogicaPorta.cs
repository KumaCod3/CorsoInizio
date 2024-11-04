using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPorta : MonoBehaviour
{
	Animator _anim;
//	public GameObject _porta;
	void Start()
	{
		_anim = GetComponent<Animator>();
	}

	void Update()
	{
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Portafogli>())
		{
			Debug.Log("entro");
			_anim.SetTrigger("ApriPorta");
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.GetComponent<Portafogli>())
		{
		//	_anim.enabled = true;
			_anim.speed = 1;
			Debug.Log("esco");
		}
	}
	public void Pausa()
	{
//		_anim.enabled = false;
		this._anim.speed = 0;
	}
}
