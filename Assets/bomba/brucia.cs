using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brucia : MonoBehaviour
{
    public Material fuoco;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        transform.GetChild(0).GetComponent<MeshRenderer>().material = fuoco;
        yield return new WaitForSeconds(1f);
        Destroy(transform.gameObject);
	}
}
