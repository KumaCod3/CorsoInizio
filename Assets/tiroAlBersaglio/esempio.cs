using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esempio : MonoBehaviour
{
    public SparaTutti _riferimantoPersonaggio;

    void Start()
    {
    }

    void Update()
    {
    }

	public void OnTriggerEnter(Collider other)
	{
        _riferimantoPersonaggio.punteggio++;
        _riferimantoPersonaggio.punteggioTesto.text = "il mio punteggio è: " + _riferimantoPersonaggio.punteggio;
        Destroy(gameObject);
	}
}
