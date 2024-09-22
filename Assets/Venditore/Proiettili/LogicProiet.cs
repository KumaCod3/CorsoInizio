using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicProiet: MonoBehaviour
{
	public int danno;
    void Start()
    {
		StartCoroutine(recicla());
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<ManaVitBox>())
		{
			Debug.Log("coolpito");
			other.GetComponent<ManaVitBox>().vitaDanneggiata(danno);
			Destroy(gameObject);
		}
	}

	private IEnumerator recicla()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
		Destroy(gameObject);
    }
	public void butta()
	{
		StartCoroutine(recicla());
	}
}
