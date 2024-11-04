using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Struttura;

public class Portafogli : MonoBehaviour
{
	public int _soldi;
	sparaCar _caricatore;
	void Start()
	{
		_caricatore = gameObject.GetComponent<sparaCar>();
	}

	void Update()
	{
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<Moneta>())
		{
			_soldi += other.GetComponent<Moneta>().valore;
			other.gameObject.GetComponent<Moneta>().Prendi();
		}

	}
	public void spendi(int prezzo)
	{
		_soldi -= prezzo;
	}
	public void prendi(Arma selected)
	{
		_caricatore._caricatore.Add(selected);
	}
}
