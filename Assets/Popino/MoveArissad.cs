using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArissad: MonoBehaviour
{
    Vector3 myPosition;
    Quaternion myOrient;
	[Range(0,1)]
	public float _accelleraz;
    bool avanti = false;
    bool indietro = false;
    bool destra = false;
    bool sinistra = false;
    public float vel = 1f;
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
		
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit info;
			Ray rr = cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
			Physics.Raycast(rr, out info);
			if (Physics.Raycast(rr, out info))
			{
				if (info.collider.GetComponent<Draggable>())
				{
					distanza = Vector3.Distance(cam.transform.position, info.transform.position);
					draggable = info.transform.gameObject;
				}
			}
		}
		if (Input.GetMouseButton(0))
		{
			if (distanza > 0)
			{
				RaycastHit info;
				Ray rr = cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
				Physics.Raycast(rr, out info);
				draggable.transform.position = Vector3.Lerp(draggable.transform.position, rr.GetPoint(distanza), 0.2f);
			}
		}
		if (Input.GetMouseButtonUp(0))
		{
			Ray rr = cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
			Physics.Raycast(rr);
			distanza = 0;
			draggable.transform.GetComponent<Rigidbody>().AddForce(rr.direction/**5000*/);
			draggable = null;
		}
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
			StartCoroutine(Parti());
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
			StartCoroutine(Fermati());
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
            moveSU(vel);
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
    void moveSU(float ve)
    {
        Vector3 move = transform.forward;
        gameObject.GetComponent<CharacterController>().Move(move * Time.deltaTime * ve);
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

	private IEnumerator Fermati()
	{
		StopCoroutine(Parti());
		float vv = vel;
		while (vv > 0)
		{
			moveSU(vv);
			yield return new WaitForSeconds(_accelleraz);
			vv--;
		}
		avanti = false;
	}
	private IEnumerator Parti()
	{
		StopCoroutine(Fermati());
		float vv = 2;
		while (vv < vel)
		{
			moveSU(vv);
			yield return new WaitForSeconds(_accelleraz);
			vv++;
		}
		avanti = true;
	}
}
