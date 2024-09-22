using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esplodi : MonoBehaviour
{
    public bool eEsplosa = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(conta());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void boom()
    {
        eEsplosa = true;

        transform.GetComponent<Renderer>().enabled = false;
        transform.gameObject.GetComponent<SphereCollider>().radius = 13;

	}
    private IEnumerator conta()
    {
        yield return new WaitForSeconds(2);
        boom();
        yield return new WaitForSeconds(0.05f);
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Destroy(transform.gameObject);
    }
}
