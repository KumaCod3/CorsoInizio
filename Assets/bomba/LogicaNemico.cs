using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LogicaNemico : MonoBehaviour
{
    public Transform _vittima;
    public float _velocitaNemico;
    public float _distanzaNemico;


    void Start()
    {
        
    }

    void Update()
    {    
        float dist = Vector3.Distance(transform.position, _vittima.position);
        if (dist <= _distanzaNemico)
        {
            transform.LookAt(_vittima);
  //          GetComponent<NavMeshAgent>().SetDestination(Vector3.Lerp(transform.position, _vittima.position, _velocitaNemico));
            GetComponent<NavMeshAgent>().SetDestination(_vittima.position);
        }
    }
}
