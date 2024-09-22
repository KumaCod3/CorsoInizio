using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinnerMenu : MonoBehaviour
{
	TextMeshProUGUI vinceX;
	TextMeshProUGUI vinceO;
	TextMeshProUGUI vinceN;
	void Start()
	{
		vinceO = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
		vinceX = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
		vinceN = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
		vinceO.gameObject.SetActive(false);
		vinceX.gameObject.SetActive(false);
		vinceN.gameObject.SetActive(false);

	}

	void Update()
	{

	}

	public void vinci(int chi)
	{
		switch (chi)
		{
			case 1:
				vinceX.gameObject.SetActive(true);
				vinceO.gameObject.SetActive(false);
				vinceN.gameObject.SetActive(false);
				break;
			case 2:
				vinceX.gameObject.SetActive(false);
				vinceO.gameObject.SetActive(true);
				vinceN.gameObject.SetActive(false);
				break;
			case 100:
				vinceX.gameObject.SetActive(false);
				vinceO.gameObject.SetActive(false);
				vinceN.gameObject.SetActive(true);
				break;
		}
	}
}
