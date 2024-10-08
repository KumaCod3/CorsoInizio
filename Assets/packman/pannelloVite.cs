using System.Collections;
using TMPro;
using UnityEngine;

public class pannelloVite: MonoBehaviour
{
	public GameObject popino;
	public GameObject finito;
	int palle;
	int vite;
	bool morto;
	bool vinto;
	int palleTot;
	int punti = 0;
	static int frutta = 0;
	int puntiMax = 400;
	int timer = 10;


	void Start()
	{
		finito.SetActive(false);
		StartCoroutine(timeOut());
	}
	void Update()
	{
		if (cambio())
		{
			aggiorna();
		}
	}
	private bool cambio()
	{
		if (punti != popino.GetComponent<vita>().punti || vite != popino.GetComponent<vita>().vite || palle != popino.GetComponent<vita>().palle || vinto != popino.GetComponent<vita>().vinto || morto != popino.GetComponent<vita>().morto)
		{
			vite = popino.GetComponent<vita>().vite;
			palle = popino.GetComponent<vita>().palle;
			vinto = popino.GetComponent<vita>().vinto;
			morto = popino.GetComponent<vita>().morto;
			punti = popino.GetComponent<vita>().punti;
			palleTot = 20 - popino.GetComponent<vita>().totPall;
			return true;
		}
		return false;
	}
	public void aggiorna()
	{
		nascondiTutto();
		transform.GetChild(5).GetComponent<TMPro.TextMeshProUGUI>().text = ("" + palleTot);
		if (vinto)
		{
			int perc = calcolaPerc();
			finito.SetActive(true);
			finito.transform.GetChild(0).gameObject.SetActive(false);
			finito.GetComponent<panelPuntiPack>().mettiVal(punti, popino.GetComponent<vita>().totPall, frutta, perc);
			return;
		}
		if (morto)
		{
			int perc = calcolaPerc();
			finito.SetActive(true);
			finito.transform.GetChild(1).gameObject.SetActive(false);
			finito.GetComponent<panelPuntiPack>().mettiVal(punti, popino.GetComponent<vita>().totPall, frutta, perc);
			return;
		}
		for (int i = 0; i < vite; i++)
		{
			transform.GetChild(2).GetChild(i).gameObject.SetActive(true);
		}
		for (int i = palle; i < 5; i++)
		{
			transform.GetChild(4).GetChild(i).gameObject.SetActive(true);
		}
		transform.GetChild(7).GetComponent<TextMeshProUGUI>().text = "" + punti;
		timer = timer + 3;
	}

	private int calcolaPerc()
	{
		float temp = punti * 100 / puntiMax;
		int fin = (int)temp;
		return fin;
	}

	private void nascondiTutto()
	{
		for (int i = 0; i < transform.GetChild(2).childCount; i++)
		{
			transform.GetChild(2).GetChild(i).gameObject.SetActive(false);
		}
		for (int i = 0; i < transform.GetChild(4).childCount; i++)
		{
			transform.GetChild(4).GetChild(i).gameObject.SetActive(false);
		}
	}

	private IEnumerator timeOut()
	{
		for (; timer >= 0; timer--)
		{
			transform.GetChild(8).GetComponent<TextMeshProUGUI>().text = "" + timer;
			yield return new WaitForSeconds(1f);
		}
		popino.GetComponent<vita>().muori();
	}
	public static void mangiafrutta()
	{
		frutta++;
	}
}
