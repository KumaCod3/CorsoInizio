using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muoviPalla : MonoBehaviour
{
    Vector3 myPosition;
    Quaternion myOrient;
    bool avanti = false;
    bool indietro = false;
    bool destra = false;
    bool sinistra = false;

    // Start is called before the first frame update
    void Start()
    {
        myPosition = transform.position;
        myOrient = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetKeyDown(KeyCode.D))
        {
            moveDX();
            destra = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.A))
        {
            moveSX();
            sinistra = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.W))
        {
            moveSU();
            avanti = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetKeyDown(KeyCode.S))
        {
            moveGU();
            indietro = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            destra = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            sinistra = false;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            avanti = false;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            indietro = false;
        }
        if (Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.GetComponent<vita>().muori();
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

