using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaProiettile : MonoBehaviour
{
    public int _danno;
    void Start()
    {
		StartCoroutine(recicla());
	}

    void Update()
    {
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.GetComponent<ManagerVita>())
        {
   //         Debug.Log("Colpito");
            other.GetComponent<ManagerVita>().vitaDanneggiata(_danno);
            gameObject.SetActive(false);
        }
	}

    private IEnumerator recicla()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
	public void butta()
	{
		StartCoroutine(recicla());
	}
}
