using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class pannelloVite : MonoBehaviour
{
    public GameObject popino;
    int palle;
    int vite;
    bool morto;
    bool vinto;
    int palleTot;
    int punti = 0;
    int puntiMax=350;
    int timer = 10;


    void Start()
    {
        StartCoroutine(timeOut());
        transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(4).gameObject.SetActive(false);
        transform.GetChild(5).gameObject.SetActive(true);
        transform.GetChild(6).gameObject.SetActive(false);
        transform.GetChild(7).gameObject.SetActive(false);
        transform.GetChild(10).gameObject.SetActive(false);
        aggiorna();
    }
    void Update()
    {
        if (cambio())
        {
            aggiorna();
        }
    }
    private bool cambio()
    {
        if (punti != popino.GetComponent<vita>().punti || vite != popino.GetComponent<vita>().vite || palle != popino.GetComponent<vita>().palle|| vinto!=popino.GetComponent<vita>().vinto|| morto!=popino.GetComponent<vita>().morto)
        {
            vite = popino.GetComponent<vita>().vite;
            palle = popino.GetComponent<vita>().palle;
            vinto = popino.GetComponent<vita>().vinto;
            morto = popino.GetComponent<vita>().morto;
            punti = popino.GetComponent<vita>().punti;
            palleTot = 20-popino.GetComponent<vita>().totPall;
            return true;
        }
        return false;
    }
    public void aggiorna()
    {
        nascondiTutto();
        transform.GetChild(5).GetComponent<TMPro.TextMeshProUGUI>().text=("To GO: "+palleTot);
        if (vinto)
        {
            transform.GetChild(4).gameObject.SetActive(true);
            transform.GetChild(6).gameObject.SetActive(true);
            int perc = calcolaPerc();
            transform.GetChild(10).gameObject.SetActive(true);
            transform.GetChild(10).GetComponent<TextMeshProUGUI>().text = "SUCCESS: " + perc +"%";
            return;
        }
        if (morto)
        {
            transform.GetChild(3).gameObject.SetActive(true);
            transform.GetChild(6).gameObject.SetActive(true);
            timer = 0;
            int perc = calcolaPerc();
            transform.GetChild(10).gameObject.SetActive(true);
            transform.GetChild(10).GetComponent<TextMeshProUGUI>().text = "SUCCESS: " + perc + "%";
            return;
        }
        for (int i = 0; i < vite; i++)
        {
            transform.GetChild(0).GetChild(i).gameObject.SetActive(true);
        }
        for (int i = palle; i < 5; i++)
        {
            transform.GetChild(2).GetChild(i).gameObject.SetActive(true);
        }
        transform.GetChild(8).GetChild(1).GetComponent<TextMeshProUGUI>().text = "" + punti;
        timer = timer + 3;
    }

	private int calcolaPerc()
	{
        float temp = punti * 100 / puntiMax ;
        int fin = (int)temp;
        return fin;
	}

	private void nascondiTutto()
    {
        for (int i = 0; i <= 6; i++)
        {
            transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i <= 4; i++)
        {
            transform.GetChild(2).GetChild(i).gameObject.SetActive(false);
        }
    }

    private IEnumerator timeOut()
    {
        for (; timer >= 0; timer--)
        {
            transform.GetChild(9).GetComponent<TextMeshProUGUI>().text = "" + timer;
            yield return new WaitForSeconds(1f);
        }
        popino.GetComponent<vita>().muori();
    }
}
