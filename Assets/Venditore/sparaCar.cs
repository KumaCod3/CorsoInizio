using Struttura;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class sparaCar: MonoBehaviour
{
	public GameObject prefabProiet;
	public Sprite logo;
	Arma proiettile;
	public List<Arma> _caricatore;
	public int _index = 0;
	public int _moltiplicatore = 1000;
	Camera cam;
	public Canvas _schermata;
	Image _logoRef;
	TextMeshProUGUI _nomeArma;
	TextMeshProUGUI _proiettiliIn;
	TextMeshProUGUI _proiettiliSu;
	TextMeshProUGUI _proiettiliRis;
	private void Start()
	{
		_logoRef = _schermata.transform.GetComponentInChildren<Image>();
		_nomeArma = _schermata.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
		_proiettiliIn = _schermata.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
		_proiettiliSu = _schermata.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
		_proiettiliRis = _schermata.transform.GetChild(4).GetComponent<TextMeshProUGUI>();

		cam = transform.GetComponentInChildren<Camera>();
		Arma prima = new Arma();
		prima._nomeArma = "Pistola base";
		prima._danno = 3;
		prima._proiettiliDiRiserva = 0;
		prima._proiettiliMaxNelCaricatore = 8;
		prima._proiettiliNelCaricatore = prima._proiettiliMaxNelCaricatore;
		prima._velocitaSparo = 7;
		prima._spariAlSecondo = 1;
		prima._proiettile = prefabProiet;
		prima.logo = this.logo;
		_caricatore.Add(prima);
		proiettile = _caricatore[_index];
		Mostra();
	}
	void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			RaycastHit info;
			Ray rr = cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
			Physics.Raycast(rr, out info);
			GameObject tmp = new GameObject();
			tmp.transform.LookAt(rr.direction);
			bang(tmp.transform.rotation);
			Destroy(tmp);
		}
		if (Input.GetKeyDown(KeyCode.K))
		{
			_index--;
			if (_index < 0)
			{
				_index = _caricatore.Count - 1;
			}
			proiettile = _caricatore[_index];
			Mostra();
		}
		if (Input.GetKeyDown(KeyCode.L))
		{
			_index++;
			if (_index >= _caricatore.Count)
			{
				_index = 0;
			}
			proiettile = _caricatore[_index];
			Mostra();
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			Ricarica();
		}
	}
	private void bang(Quaternion direz)
	{
		if (proiettile._proiettiliNelCaricatore > 0)
		{
			GameObject x = Instantiate(proiettile._proiettile, transform.position + transform.forward * 0.5f, direz);
			x.GetComponent<LogicProiet>().danno = proiettile._danno;
			x.transform.Rotate(new Vector3(-90, 0, 0));
			x.GetComponent<Rigidbody>().AddForce(-x.transform.up * _caricatore[_index]._velocitaSparo * _moltiplicatore);
			proiettile._proiettiliNelCaricatore -= 1;
			_caricatore[_index] = proiettile;
			Mostra();
		}
		else
		{
			_nomeArma.SetText("Ricaricaaa!!!");
		}

	}
	public void Ricarica()
	{
		if (proiettile._proiettiliDiRiserva > 0 && proiettile._proiettiliNelCaricatore < proiettile._proiettiliMaxNelCaricatore)
		{
			_nomeArma.SetText(proiettile._nomeArma);
			proiettile._proiettiliNelCaricatore++;
			proiettile._proiettiliDiRiserva--;
			_caricatore[_index] = proiettile;
			Mostra();
			Ricarica();
		}
	}

	private void Mostra()
	{
		_logoRef.GetComponent<Image>().sprite = proiettile.logo;
		_nomeArma.SetText(proiettile._nomeArma);
		_proiettiliIn.SetText(proiettile._proiettiliNelCaricatore + "");
		_proiettiliSu.SetText("/ " + proiettile._proiettiliMaxNelCaricatore);
		_proiettiliRis.SetText(proiettile._proiettiliDiRiserva + "");
	}
}
