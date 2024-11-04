using System.Collections;
using TMPro;
using UnityEngine;

public class SchermoPuntiTiro: MonoBehaviour
{
	public bool _tm = false;
	public BuildWalls scrip;
	public int time;
	TextMeshProUGUI tempo;
	int civili;
	TextMeshProUGUI civ;
	TextMeshProUGUI civOn;
	int nemici;
	TextMeshProUGUI nem;
	TextMeshProUGUI nemOn;
	int boss;
	TextMeshProUGUI bos;
	TextMeshProUGUI bossOn;
	int point;
	public int poinFin;
	TextMeshProUGUI poinOn;
	TextMeshProUGUI poin;
	public bool fine = false;
	public GameObject scherFine;
	GameObject map;
	int civiliON;
	int nemiciON;
	int bossON;

	void Start()
	{

		civili = scrip.numCivili;
		nemici = scrip.numBersagli;
		boss = scrip.numSuper;
		point = ((scrip.bersaglio.GetComponent<Bersaglio>().valore) * nemici) + ((scrip.bersaglioSuper.GetComponent<Bersaglio>().valore) * boss);
		civiliON = scrip.numCivili;
		nemiciON = scrip.numBersagli;
		bossON = scrip.numSuper;

		tempo = gameObject.transform.GetChild(5).GetComponent<TextMeshProUGUI>();
		civ = gameObject.transform.GetChild(6).GetComponent<TextMeshProUGUI>();
		civOn = gameObject.transform.GetChild(7).GetComponent<TextMeshProUGUI>();
		nem = gameObject.transform.GetChild(8).GetComponent<TextMeshProUGUI>();
		nemOn = gameObject.transform.GetChild(9).GetComponent<TextMeshProUGUI>();
		bos = gameObject.transform.GetChild(10).GetComponent<TextMeshProUGUI>();
		bossOn = gameObject.transform.GetChild(11).GetComponent<TextMeshProUGUI>();
		poinOn = gameObject.transform.GetChild(13).GetComponent<TextMeshProUGUI>();
		poin = gameObject.transform.GetChild(12).GetComponent<TextMeshProUGUI>();
		map = gameObject.transform.GetChild(15).gameObject;

		poin.text = "" + point;
		scherFine.SetActive(false);
		tempo.text = "" + time;
		civ.text = "" + civili;
		civOn.text = "" + civili;
		nem.text = "" + nemici;
		nemOn.text = "" + nemici;
		bossOn.text = "" + boss;
		bos.text = "" + boss;
		poinOn.text = "" + point;

		StartCoroutine(timeOut());
	}

	void Update()
	{
		if (fine)
		{
			map.SetActive(false);
			int scor = (int)((float)poinFin / (float)point * 100f);
			scherFine.SetActive(true);
			int[] dat = { civili, civiliON, nemici, nemiciON, boss, bossON, poinFin, point, scor };
			scherFine.GetComponent<managerScerPuntFPS>().setDati(dat);
		}
	}
	public void killEnem()
	{
		nemici--;
		nem.text = "" + nemici;
	}
	public void killCiv()
	{
		civili--;
		civ.text = "" + civili;
		time -= 5;
	}
	public void killBos()
	{
		boss--;
		bos.text = "" + boss;
	}

	private IEnumerator timeOut()
	{
		for (; time >= 0; time--)
		{
			if (_tm)
			{
				time -= 3;
				_tm = false;
			}
			tempo.text = "" + time;
			yield return new WaitForSeconds(1f);
		}
		fine = true;
	}
}
