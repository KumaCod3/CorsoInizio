using TMPro;
using UnityEngine;

public class TrisCamera: MonoBehaviour
{
	public TrisGameManager _tgm;

	GameObject scRosso;
	GameObject scBlu;

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

		scRosso = transform.GetChild(14).gameObject;
		scBlu = transform.GetChild(15).gameObject;
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
	public void faiScBlu()
	{
		scRosso.SetActive(false);
		scBlu.SetActive(true);
		toccaO.gameObject.SetActive(true);
		toccaX.gameObject.SetActive(false);
	}
	public void faiScRos()
	{
		scRosso.SetActive(true);
		scBlu.SetActive(false);
		toccaX.gameObject.SetActive(true);
		toccaO.gameObject.SetActive(false);
	}
}
