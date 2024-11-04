using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vaga : MonoBehaviour
{
    // per far muovere ingiro i mostri
    private float vel=5;
    bool muoviX = false;
    bool muoviZ = false;
    bool pos = true;
    float maxX;
    float maxZ;
    float minX;
    float minZ;
    
//     Material matt;
    // Start is called before the first frame update
    void Start()
    {
        RaycastHit info;
        Physics.Raycast(transform.position, transform.forward, out info); 
        maxZ = info.collider.gameObject.transform.position.z;

        RaycastHit info2;
        Physics.Raycast(transform.position, -transform.forward, out info2);
        minZ= info2.collider.gameObject.transform.position.z;


        RaycastHit info3;
        Physics.Raycast(transform.position, transform.right, out info3);
        maxX=info3.collider.gameObject.transform.position.x;

        RaycastHit info4;
        Physics.Raycast(transform.position, -transform.right, out info4);
        minX= info4.collider.gameObject.transform.position.x;

        float distx = maxX-minX;
        float distz= maxZ-minZ;
        maxX = maxX - 5;
        minX = minX + 5;
        maxZ = maxZ - 5;
        minZ = minZ + 5;
        if (distx > distz)
        {
            muoviX = true;
        }
        else 
        {
            muoviZ = true;
        }

    }

	private IEnumerator vagaZ()
	{
        if (pos)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, (transform.position.z + Time.deltaTime * vel));
            if (transform.position.z >= maxZ)
            {
                pos = false;
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, (transform.position.z - Time.deltaTime * vel));
            if (transform.position.z <= minZ)
            {
                pos = true;
            }
        }
        yield return new WaitForSeconds(0.2f);
    }

	private IEnumerator vagaX()
	{
        if (pos)
        {
            transform.position = new Vector3((transform.position.x + Time.deltaTime * vel), transform.position.y, transform.position.z );
            if (transform.position.x >= maxX)
            {
                pos = false;
            }
        }
        else
        {
            transform.position = new Vector3((transform.position.x - Time.deltaTime * vel), transform.position.y, transform.position.z);
            if (transform.position.x <= minX)
            {
                pos = true;
            }
        }
        yield return new WaitForSeconds(0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (muoviZ)
        {
            StartCoroutine(vagaZ());
        }
        if (muoviX)
        {
            StartCoroutine(vagaX());
        }
    }
}
