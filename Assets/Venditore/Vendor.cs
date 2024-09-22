using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Struttura;

public class Vendor : MonoBehaviour
{
	public List<Arma> _vetrina;
	private int _index = 0;
	private int _prezzo;
	TextMeshProUGUI _tipoGU;
	TextMeshProUGUI _prezzoGU;
	TextMeshProUGUI _dannoGU;
	TextMeshProUGUI _portafogliGU;
	TextMeshProUGUI _poraccio;
	public Canvas _menu;
	Arma _selected;
	bool _attivo = false;
	Portafogli _por;
	bool _out = false;

	private void Poraccio(bool tr)
	{
		_tipoGU.gameObject.SetActive(!tr);
		_prezzoGU.gameObject.SetActive(!tr);
		_dannoGU.gameObject.SetActive(!tr);
		_portafogliGU.gameObject.SetActive(!tr);
		_poraccio.gameObject.SetActive(tr);
		_menu.transform.GetChild(5).gameObject.SetActive(!tr);
		_menu.transform.GetChild(6).gameObject.SetActive(!tr);
		_menu.transform.GetChild(7).gameObject.SetActive(!tr);
		_menu.transform.GetChild(8).gameObject.SetActive(!tr);
	}

	void Start()
	{
		_tipoGU = _menu.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
		_prezzoGU = _menu.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
		_dannoGU = _menu.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
		_portafogliGU = _menu.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
		_poraccio= _menu.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
		_poraccio.gameObject.SetActive(false);
	}
	private void Update()
	{
		_menu.gameObject.SetActive(_attivo);
		gameObject.GetComponent<MeshRenderer>().enabled = !_attivo;
		if (Input.GetKeyDown(KeyCode.M) /*&& _selected*/)
		{
			Poraccio(false);
			_index++;
			if (_index >= _vetrina.Capacity)
			{
				_index = 0;
			}
			mostra();
		}
		if (Input.GetKeyDown(KeyCode.N) /*&& _selected*/)
		{
			Poraccio(false);
			_index--;
			if (_index < 0)
			{
				_index = _vetrina.Capacity - 1;
			}
			mostra();
		}
		if (Input.GetKeyDown(KeyCode.Return) /*&& _selected*/)
		{
			Poraccio(false);
			if (!_out)
			{
				compra();
			}
		}
	}

	public bool compra()
	{
		if (_por._soldi < _prezzo)
		{
			Poraccio(true);
			return false;
		}
		else
		{
			_por.spendi(_prezzo);
			_por.prendi(_selected);
			_vetrina.RemoveAt(_index);
			_index = 0;
			mostra();
			return true;
		}
	}

	public void mostra()
	{
		if (_index < _vetrina.Count)
		{
			_selected = _vetrina[_index];
			_tipoGU.SetText(_selected._nomeArma);
			_prezzoGU.SetText(_selected._costo + " $");
			_dannoGU.SetText(_selected._danno + " ");
			_portafogliGU.SetText(_por._soldi + " $");
			_prezzo = _selected._costo;
		}
		else
		{
			_tipoGU.SetText("SOLD OUT");
			_prezzoGU.SetText( " $");
			_dannoGU.SetText("");
			_portafogliGU.SetText(_por._soldi + " $");
			_prezzo = 0;
			_out = true;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Portafogli>())
		{
			_attivo = true;
			_por = other.GetComponent<Portafogli>();
			mostra();
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.GetComponent<Portafogli>())
		{
			_attivo = false;
		}
	}

}
