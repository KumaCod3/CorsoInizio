using System.Collections;
using TMPro;
using UnityEngine;

public class vita: MonoBehaviour
{
	public GameObject supCic;
	public int vite;
	public int palle = 0;
	public bool vinto = false;
	public bool morto = false;
	public int totPall = 0;
	int cont = 10;
	public int punti = 0;
	public TextMeshProUGUI txt;
	private void Update()
	{
		if (palle == 5)
		{
			palle = 0;
			creaSuperCiccia();
		}
		if (vite <= 0)
		{
			muori();
		}
		if (totPall == 20)
		{
			vinto = true;
			gameObject.SetActive(false);
		}
		if (gameObject.transform.position.y < -13)
		{
			muori();
		}
	}

	public void muori()
	{
		morto = true;
		gameObject.SetActive(false);
	}

	private void creaSuperCiccia()
	{
		txt.gameObject.SetActive(true);
		int randX = Random.Range(-20, 20);
		int randZ = Random.Range(-20, 20);
		if (randX == 0)
		{
			randX = 1;
		}
		if (randZ == 0)
		{
			randZ = 1;
		}
		Vector3 position = new Vector3(randX * 5, gameObject.transform.position.y, randZ * 5);
		Quaternion rotation = gameObject.transform.rotation;
		GameObject x = Instantiate(supCic, position, rotation);
		StartCoroutine(conta(x));
	}

	private IEnumerator conta(GameObject x)
	{

		for (int i = cont; i >= 0; i--)
		{
			if (x)
			{
				txt.text = "Time left for BONUS: " + cont;
				yield return new WaitForSeconds(1f);
				cont--;
			}
		}
		Destroy(x);
		txt.gameObject.SetActive(false);
		cont = 10;
	}
}
