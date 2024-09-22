using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bruciaMe: MonoBehaviour
{
    public Material fuoco;
    public Material normale;
    void Start()
    {
    }
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<esplodi>())
        {
            if (other.gameObject.GetComponent<esplodi>().eEsplosa)
            {
                StartCoroutine(burn());
            }
        }
    }

	private IEnumerator burn()
	{
        transform.GetChild(0).GetComponent<MeshRenderer>().material=fuoco;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<ManagerVita>().vitaDanneggiata(10);
        yield return new WaitForSeconds(0.2f);
        transform.GetChild(0).GetComponent<MeshRenderer>().material = normale;
    }
}
