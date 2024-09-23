using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Terminator : MonoBehaviour
{
	public GameObject _obbiettivo;
	public float _distanzaMaxNemico;
	public float _distanzaMinNemico;
	public GameObject _proiettile;
	[Range(0.5f,5f)]
	public float _frequenzaSparo;
	private int _poolSize = 9;
	private int _index;
	private GameObject[] _pool;
	private Animator anim;
	public bool _walking;
	private Transform _cartucce;
	void Start()
	{
		anim = GetComponent<Animator>();
		_poolSize = _poolSize - (int)_frequenzaSparo;
		_pool = new GameObject[_poolSize];
		_cartucce = gameObject.transform.GetChild(4);
		for (int i = 0; i < _poolSize; i++)
		{
			GameObject x = Instantiate(_proiettile);
			x.transform.SetParent(_cartucce);
			x.SetActive(false);
			_pool[i] = x;
		}
		StartCoroutine(uccidi());
	}
	private void Update()
	{
		anim.SetBool("isWalking", _walking);
		float dist = Vector3.Distance(transform.position, _obbiettivo.transform.position);
		if (dist <= _distanzaMaxNemico && dist >= _distanzaMinNemico)
		{
			transform.LookAt(_obbiettivo.transform);
			_walking = true;
			GetComponent<NavMeshAgent>().SetDestination(_obbiettivo.transform.position);
		}
		else
		{
			transform.LookAt(_obbiettivo.transform);
			_walking = false;
			GetComponent<NavMeshAgent>().SetDestination(gameObject.transform.position);
		}
	}

	private IEnumerator uccidi()
	{
		spara();
		yield return new WaitForSeconds(_frequenzaSparo);
		StartCoroutine(uccidi());
	}

	private void spara()
	{
		Quaternion direz = transform.rotation;
		GameObject x = _pool[_index];
		aggiornaIndice();
		x.SetActive(true);
		Vector3 temp = transform.position;
		temp.y += 2.2f;
		x.transform.position = temp + transform.forward * 1f;
		x.transform.rotation = direz;
		x.transform.Rotate(new Vector3(0, 0, 0));
		x.GetComponent<Rigidbody>().AddForce(x.transform.forward * 3000f);
		x.GetComponent<LogicaProiettile>().butta();
	}

	private void aggiornaIndice()
	{
		if (_index < _poolSize - 1)
		{
			_index++;
		}
		else
		{
			_index = 0;
		}
	}
}
