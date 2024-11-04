using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spara : MonoBehaviour
{
	public Camera cam;
	GameObject obb;
	public GameObject colpo;

	void Start()
    {
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
			float aimDistance = 1000f;
			Vector3 aimpoint;
			RaycastHit info;
            Ray rr = cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(rr, out info);
			Debug.Log("sparo");
			if (Physics.Raycast(rr, out info))
			{
				bang(info.point);
			}
			else
			{
				aimpoint = rr.origin + rr.direction * aimDistance;
				bang(aimpoint);
			}
        }

    }
	private void bang(Vector3 Target)
	{
		GameObject x = Instantiate(colpo);
		x.SetActive(false);
		x.transform.position = transform.position;
		x.transform.LookAt(Target);
		x.transform.position += x.transform.forward * 2f;
		x.SetActive(true);
		x.GetComponent<Rigidbody>().AddForce(x.transform.forward * 3000f);
	}

}
