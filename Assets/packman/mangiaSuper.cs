using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mangiaSuper : MonoBehaviour
{
	private void Start()
	{

	}

	

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<vita>())
		{
			other.GetComponent<vita>().vite++;
			other.GetComponent<vita>().punti = other.GetComponent<vita>().punti + 50;
			Destroy(gameObject);
		}
	}
	
}
