using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class menuPunta: MonoBehaviour
{
    public bool _tm = false;
    public int time;
    TextMeshProUGUI tempo;
 
    public int nemici;
    TextMeshProUGUI nem;
 
    //public int boss;
    //TextMeshProUGUI bos;
 
    public int poinFin;
    public bool fine = false;
    public bool vinto = true;
    GameObject over;

    void Start()
    {
        tempo = gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        nem = gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        //bos = gameObject.transform.GetChild(10).GetComponent<TextMeshProUGUI>();
        over = gameObject.transform.GetChild(5).gameObject;

        over.SetActive(false);
        tempo.text = "" + time;
        nem.text = "" + nemici;
        //bos.text = "" + boss;

        StartCoroutine(timeOut());
    }

    void Update()
    {
        if (nemici <= 0)
        {
            fine = true;
            vinto = true;
        }
        if (fine)
        {
            over.SetActive(true);
            if (vinto)
            {
                over.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = "" + poinFin;
                over.transform.GetChild(0).gameObject.SetActive(true);
                over.transform.GetChild(2).gameObject.SetActive(true);
                over.transform.GetChild(3).gameObject.SetActive(true);
                over.transform.GetChild(4).gameObject.SetActive(true);
                over.transform.GetChild(5).gameObject.SetActive(true);
                over.transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                over.transform.GetChild(0).gameObject.SetActive(true);
                over.transform.GetChild(1).gameObject.SetActive(true);
                over.transform.GetChild(3).gameObject.SetActive(true);
                over.transform.GetChild(2).gameObject.SetActive(false);
                over.transform.GetChild(4).gameObject.SetActive(false);
                over.transform.GetChild(5).gameObject.SetActive(false);
            }
        }
    }
    public void killEnem()
    {
        nemici--;
        nem.text = "" + nemici;
        poinFin += 10;
    }


    //public void killBos()
    //{
    //    boss--;
    //    bos.text = "" + boss;
    //    poinFin += 50;
    //}

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
