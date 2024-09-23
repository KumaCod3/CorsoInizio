using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopViewCam : MonoBehaviour
{
    public float _velocita;
    public GameObject pers;
    bool avanti = false;
    bool indietro = false;
    bool destra = false;
    bool sinistra = false;
    bool centra = true;
    float min=8;
    float max = 100;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            centra = false;
            float newY= transform.position.y + Input.GetAxis("Mouse ScrollWheel")*10;
            if (newY > min && newY < max)
            {
                Vector3 newPos = new Vector3(transform.position.x, newY, transform.position.z);
                transform.position = newPos;
            }
        }


        if (Input.GetKeyDown(KeyCode.Return))   // centra cam con invio
        {
            moveCent();
            centra = true;
        }
  
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            moveDX();
            destra = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            moveSX();
            sinistra = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            moveSU();
            avanti = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            moveGU();
            indietro = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            destra = false;
            centra = false;

        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            sinistra = false;
            centra = false;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            avanti = false;
            centra = false;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            indietro = false;
            centra = false;
        }

        if (centra)
        {
            moveCent();
        }
        if (destra)
        {
            moveDX();
        }
        if (sinistra)
        {
            moveSX();
        }
        if (avanti)
        {
            moveSU();
        }
        if (indietro)
        {
            moveGU();
        }
    }

	private void moveCent()
	{
        Vector3 temp = pers.transform.position;
        temp.y = gameObject.transform.position.y;
        transform.position = Vector3.Lerp(transform.position, temp , _velocita) ;
    }

	void moveDX()
    {
        Vector3 dir = new Vector3(5f, 0, 0);
        GetComponent<Rigidbody>().AddForce(dir * 50f);
    }
    void moveSX()
    {
        Vector3 dir = new Vector3(-5f, 0, 0);
        GetComponent<Rigidbody>().AddForce(dir * 50f);
    }
    void moveSU()
    {
        Vector3 dir = new Vector3(0, 0, 5f);
        GetComponent<Rigidbody>().AddForce(dir * 50f);
    }
    void moveGU()
    {
        Vector3 dir = new Vector3(0, 0, -5f);
        GetComponent<Rigidbody>().AddForce(dir * 50f);

    }

}
