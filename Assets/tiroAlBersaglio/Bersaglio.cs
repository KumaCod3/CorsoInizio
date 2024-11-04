using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bersaglio : MonoBehaviour
{
    public bool vivo = true;
    public bool enem=false;
    public bool civ=false;
    public bool bos=false;
    public Material mat;
    public int valore;
    public float attesa;
    bool go = true;
    bool ret = false;
    public int vel;
    public float mod;
    float min;
    float max;
    void Start()
    {
        max = 1.5f - mod;
        min = -2f - mod;
    }

	private void Update()
	{

        if (ret)
        {
            transform.position = new Vector3(transform.position.x, (transform.position.y + Time.deltaTime * vel), transform.position.z);
            if (transform.position.y >= max)
            {
                StartCoroutine(sali());
              ret = false;
            }
        }
        if (go)
        {
            transform.position = new Vector3(transform.position.x, (transform.position.y - Time.deltaTime * vel), transform.position.z);
            if (transform.position.y <= min)
            {
                StartCoroutine(scendi());
                go = false;
            }
        }
    }
	private IEnumerator scendi()
    {
        reSpawn();
        yield return new WaitForSeconds(0.2f);
        ret = true;
    }
    private IEnumerator sali()
    {
        yield return new WaitForSeconds(attesa);
        go = true;
    }
    public void reSpawn()
    {
        // regola coordinate!!!!
        float randomX = Random.Range(0, 19) * 10 - 95;
        float randomZ = Random.Range(0, 19) * 10 - 95;
        Vector3 pos = new Vector3(randomX, -1, randomZ);
        transform.position = pos;
    }
    public IEnumerator muori()
    {
        gameObject.transform.GetComponentInChildren<MeshRenderer>().material = mat;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
