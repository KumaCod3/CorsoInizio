using TMPro;
using UnityEngine;

public class panelPuntiPack: MonoBehaviour
{
	TextMeshProUGUI punt;
	TextMeshProUGUI pall;
	TextMeshProUGUI frut;
	TextMeshProUGUI percc;

	void Start()
	{
		punt = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
		pall = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
		frut = transform.GetChild(4).GetComponent<TextMeshProUGUI>();
		percc = transform.GetChild(5).GetComponent<TextMeshProUGUI>();
	}

	public void mettiVal(int punti, int palle, int frutta, int perc)
	{
		punt.SetText(punti + "");
		pall.SetText(palle + "");
		frut.SetText(frutta + "");
		percc.SetText(perc + "");
	}
}
