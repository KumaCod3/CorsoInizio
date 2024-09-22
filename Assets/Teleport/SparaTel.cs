using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Struttura;
using UnityEngine.UI;
using TMPro;
using System;

public class SparaTel: MonoBehaviour
{

	public int _index = 0;
	public Camera cam;
//	public Canvas _schermata;
//	TextMeshProUGUI _nomeArma;
	GameObject obb;
//	bool pres = false;
	float piano=0;
	float alt;
	Vector3 pos=new Vector3(-1000,-1000,-1000);
	public GameObject _puntatore;
	GameObject punt;

	private void Start()
	{
		//		_nomeArma = _schermata.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

		//		cam = transform.GetComponentInChildren<Camera>();
		alt = transform.position.y;
		punt=Instantiate(_puntatore);
		punt.SetActive(false);
		Mostra();
	}
	void Update()
	{
		if (Input.GetMouseButton(1))
		{
			RaycastHit info;
			Ray rr = cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
			Physics.Raycast(rr, out info);
		}

		if (Input.GetMouseButton(0))
		{
			RaycastHit info;
			Ray rr = cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
			Physics.Raycast(rr, out info);
			if (!Physics.Raycast(rr, out info))
			{
				// sparo a vuoto
			}
			else
			{
				obb = info.collider.gameObject;
				pos = info.point;

				if (obb.GetComponent<SuperficieTeletrasportabile>())
				{
					ShowPoint(pos);				
				}
				else
				{
					pos.y = piano;
					ShowPoint(pos);
					Debug.Log("errore puntamento teletrasporto");
				}
			}
		}
		if (Input.GetMouseButtonUp(0))
		{
			Teleport(pos);
			pos = new Vector3(-1000,-1000,-1000);
			punt.SetActive(false);
		}
	}

	private void ShowPoint(Vector3 pos)
	{
		pos.y = pos.y + 1;
		punt.transform.position = pos;
		pos.y = pos.y - 1;
		punt.SetActive(true);
	}

	private void Teleport(Vector3 posiz)
	{
		if (posiz.x != -1000)
		{

			Debug.Log("vadoooo");
			posiz.y = alt;
			gameObject.transform.position = posiz;
			StartCoroutine(Allarga());

		}
	}

	private void Mostra()
	{

//		_nomeArma.SetText("nuovo testo per UI");

	}

	private IEnumerator Allarga()
	{
		yield return new WaitForSeconds(0.4f);
		gameObject.GetComponent<CapsuleCollider>().radius = 1.5f;
		Debug.Log("allargo");
		yield return new WaitForSeconds(0.5f);
		gameObject.GetComponent<CapsuleCollider>().radius = 0.4f;
	}
}
