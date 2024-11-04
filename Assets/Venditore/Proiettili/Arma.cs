using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Struttura
{
	[System.Serializable]
	public struct Arma
	{
		public GameObject _proiettile;
		public string _nomeArma;
		public int _proiettiliNelCaricatore;
		public int _proiettiliMaxNelCaricatore;
		public int _proiettiliDiRiserva;
		public float _velocitaSparo;
		public float _spariAlSecondo;
		public int _danno;
		public int _costo;
		public Sprite logo;

	}
}