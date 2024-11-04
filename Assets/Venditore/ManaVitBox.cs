using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaVitBox: MonoBehaviour
{
    public float _vita;
    public float _vitaMax;
    public Slider slider;
	public Camera _cam;
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
		gameObject.transform.GetChild(0).LookAt(_cam.transform.position);
    }
}
