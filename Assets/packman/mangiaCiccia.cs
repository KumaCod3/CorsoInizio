using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mangiaCiccia : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<vita>())
		{
			other.GetComponent<vita>().palle++;
			other.GetComponent<vita>().totPall++;
			other.GetComponent<vita>().punti= other.GetComponent<vita>().punti+10;
			Destroy(gameObject);
		}
	}
}
