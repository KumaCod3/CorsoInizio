using TMPro;
using UnityEngine;

public class managerScerPuntFPS: MonoBehaviour
{
	TextMeshProUGUI civ;
	TextMeshProUGUI civOn;
	TextMeshProUGUI enem;
	TextMeshProUGUI enemOn;
	TextMeshProUGUI bss;
	TextMeshProUGUI bssOn;
	TextMeshProUGUI pnt;
	TextMeshProUGUI pntOn;
	TextMeshProUGUI score;

	void Start()
	{
		civ = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
		civOn = gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
		enem = gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
		enemOn = gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
		bss = gameObject.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
		bssOn = gameObject.transform.GetChild(5).GetComponent<TextMeshProUGUI>();
		pnt = gameObject.transform.GetChild(6).GetComponent<TextMeshProUGUI>();
		pntOn = gameObject.transform.GetChild(7).GetComponent<TextMeshProUGUI>();
		score = gameObject.transform.GetChild(8).GetComponent<TextMeshProUGUI>();
	}

	public void setDati(int[] dati)
	{
		civ.SetText(dati[0] + "");
		civOn.SetText(dati[1] + "");
		enem.SetText(dati[2] + "");
		enemOn.SetText(dati[3] + "");
		bss.SetText(dati[4] + "");
		bssOn.SetText(dati[5] + "");
		pnt.SetText(dati[6] + "");
		pntOn.SetText(dati[7] + "");
		score.SetText(dati[8] + " %");
	}
}
