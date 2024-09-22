using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrisCamera : MonoBehaviour
{
	public TrisGameManager _tgm;
	Color _rossoBG = new Color(120 / 255f, 24 / 255f, 31 / 255f);
	Color _bluBG = new Color(17 / 255f, 31 / 255f, 70 / 255f);
	TextMeshProUGUI toccaX;
	TextMeshProUGUI toccaO;
	TextMeshProUGUI puntiX;
	TextMeshProUGUI puntiO;
	private int vince1 = 0;
	private int vince2 = 0;


	private void Start()
	{
		toccaO = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
		toccaX = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
		puntiX = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
		puntiO = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
		toccaX.gameObject.SetActive(false);
		toccaO.gameObject.SetActive(false);
	}
	void Update()
	{
		if (_tgm._turno)
		{
			gameObject.GetComponent<Image>().color = _rossoBG;
			toccaX.gameObject.SetActive(true);
			toccaO.gameObject.SetActive(false);
		}
		else
		{
			gameObject.GetComponent<Image>().color = _bluBG;
			toccaO.gameObject.SetActive(true);
			toccaX.gameObject.SetActive(false);
		}
	}
	public void vince(int chi)
	{
		if (chi == 1)
		{
			vince1 += 1;
			puntiX.SetText("" + vince1);
		}
		if (chi == 2)
		{
			vince2 += 1;
			puntiO.SetText("" + vince2);
		}
	}
}
