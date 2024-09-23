using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class but : MonoBehaviour
{
	private bool inn = false;
	GameObject muri;
	int time=3;
	GameObject me;
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<vita>())
		{
			inn = true;
				
		}
	}
	private IEnumerator tran()
	{
		muri.SetActive(false);
		yield return new WaitForSeconds(time);
		muri.SetActive(true);
		
	}
	private void Start()
	{
		muri = gameObject.transform.parent.GetChild(0).gameObject;
		me = gameObject.transform.parent.GetChild(1).gameObject;
	}

	private void Update()
	{
		if (inn)
		{
			me.GetComponent<vita>().vite -=1;
			StartCoroutine(tran());
			inn = false;
		}
	}
}
