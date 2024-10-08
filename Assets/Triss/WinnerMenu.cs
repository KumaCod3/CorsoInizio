using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinnerMenu: MonoBehaviour
{
	Image vinceX;
	Image vinceO;
	TextMeshProUGUI vinceN;
	void Start()
	{
		vinceO = transform.GetChild(1).GetComponent<Image>();
		vinceX = transform.GetChild(0).GetComponent<Image>();
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
