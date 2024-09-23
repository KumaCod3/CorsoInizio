using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTel: MonoBehaviour
{
    Vector3 myPosition;
    Quaternion myOrient;
    bool avanti = false;
    bool indietro = false;
    bool destra = false;
    bool sinistra = false;
    public float vel = 5f;
	public Camera cam;
	float distanza;
	GameObject draggable;
	void Start()
    {
        myPosition = transform.position;
        myOrient = transform.rotation;
    }
	void Update()
    {
		
		if (Input.GetKeyDown(KeyCode.D))
        {
            moveDX();
            destra = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveSX();
            sinistra = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveSU();
            avanti = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveGU();
            indietro = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            vel = 15f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            vel = 5f;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            destra = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            sinistra = false;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            avanti = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            indietro = false;
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
        transform.Rotate(new Vector3(0,2,0));
    }
    void moveSX()
    {
        transform.Rotate(new Vector3(0, -2, 0));
    }
    void moveSU()
    {
        Vector3 move = transform.forward;
        gameObject.GetComponent<CharacterController>().Move(move * Time.deltaTime * vel);
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        myPosition = transform.position;
    }
    void moveGU()
    {
        Vector3 move = transform.forward;
        gameObject.GetComponent<CharacterController>().Move(-move * Time.deltaTime * vel);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        myPosition = transform.position;
    }
}
