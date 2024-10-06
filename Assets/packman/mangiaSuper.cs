using UnityEngine;

public class mangiaSuper: MonoBehaviour
{
	private void Start()
	{
		vita.frut = true;
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<vita>())
		{
			other.GetComponent<vita>().vite++;
			other.GetComponent<vita>().punti = other.GetComponent<vita>().punti + 50;
			pannelloVite.mangiafrutta();
			vita.frut = false;
			Destroy(gameObject);
		}
	}

}
