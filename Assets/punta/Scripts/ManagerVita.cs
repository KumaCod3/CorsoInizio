using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerVita : MonoBehaviour
{
    public float _vita;
    public float _vitaMax;
    public Slider slider;
    public GameObject menu;
    public bool _eVivo = true;
    float vitaCorrente {
        get
        {
            return _vita / _vitaMax;
        }
    }

    void Start()
    {
        _vita = _vitaMax;
        slider.value = vitaCorrente;

    }

    public void vitaDanneggiata(int dannoPreso)
    {
        _vita -= dannoPreso;
        if (_vita < 1)
        {
            _eVivo = false;
            menu.GetComponent<menuPunta>().vinto = false;
            menu.GetComponent<menuPunta>().fine = true;
 //           Destroy(gameObject);
            gameObject.SetActive(false);
        }
        if (_vita > _vitaMax)
        {
            _vita = _vitaMax;
        }
        slider.value = vitaCorrente;
    }
    void Update()
    {
    }
}
