using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunAround : MonoBehaviour
{
    public Camera cam;
    void Start()
    {
        GetComponent<NavMeshAgent>().updateRotation = false;
    }

    void Update()
    {
        Vector3 punto=transform.position;

        RaycastHit raggioInfo;
        Ray raggio = cam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(raggio, out raggioInfo);
        punto = raggioInfo.point;
        punto.y = gameObject.transform.position.y;
        transform.LookAt(punto);

        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<NavMeshAgent>().SetDestination(punto);
        }
    }
}
