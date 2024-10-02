using UnityEngine;

public class Bottone: MonoBehaviour
{
	public GameObject dropD;
	public int indice = 0;
	public GameObject desc;

	public void OnClick()
	{
		indice = dropD.GetComponent<indice>().getIndex();
		PlayerPrefs.SetInt("gioco", indice);
		desc.SetActive(true);
		desc.GetComponent<ControllerDescrizioni>().setGame(indice);
		gameObject.SetActive(false);
	}
}
