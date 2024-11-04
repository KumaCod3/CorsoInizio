using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VenditoreArissad : MonoBehaviour
{
	public bool vendo = false;
	private bool entro = false;
	Animator _anim;
	NavMeshAgent _nm;
	public Transform _player;
	GameObject _plyr;
	IEnumerator cr = null;

	void Start()
	{
		_anim = gameObject.GetComponent<Animator>();
		_nm = gameObject.GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		Vector3 mira = _player.position;
		mira.y = transform.position.y;
		transform.LookAt(mira);
		if (Input.GetKeyDown(KeyCode.P)&&entro)
		{
			cr = vendi();
			StartCoroutine(cr);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<CharacterMovement>())
		{
			entro = true;
			_plyr = other.gameObject;
			Debug.Log("vendo a " + _plyr.name);
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.GetComponent<CharacterMovement>())
		{
			StopCoroutine(cr);
			entro = false;
			_anim.SetBool("vendo", false);
			_plyr = null;
		}
	}
	private IEnumerator vendi()
	{
		_anim.SetBool("vendo", true);
		yield return new WaitForSeconds(1.5f);

		yield return new WaitUntil(FineVendita);

		_anim.SetBool("vendo", false);
	}

	private IEnumerator pro()
	{
		yield return new WaitForSeconds(5.5f);
	}
	private bool FineVendita()
	{
		return vendo;
	}


}
