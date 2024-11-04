using UnityEngine;
using UnityEngine.UI;

public class TrisButt: MonoBehaviour
{
	public Sprite _nulla;
	public Sprite _x;
	public Sprite _o;
	public bool _inUso;
	public int _chi;
	public TrisGameManager _tgm;
	void Start()
	{
		_inUso = false;
		_chi = 0;
	}

	void Update()
	{
	}

	public void OnClick()
	{
		if (_inUso == false && _tgm._pause == false)
		{
			if (_tgm._turno)
			{
				_chi = 1;
				gameObject.GetComponent<Button>().GetComponent<Image>().sprite = _x;
				actiAlpha(1);
				_inUso = true;
				_tgm._turno = false;
				_tgm.nTurni++;
			}
		}
	}

	private void actiAlpha(int x)
	{
		var tempColor = gameObject.GetComponent<Button>().GetComponent<Image>().color;
		tempColor.a = x;
		gameObject.GetComponent<Button>().GetComponent<Image>().color = tempColor;
	}
	public void resetta()
	{
		_inUso = false;
		_chi = 0;
		gameObject.GetComponent<Button>().GetComponent<Image>().sprite = _nulla;
		actiAlpha(0);
	}

	public void schiscia()
	{
		_chi = 2;
		gameObject.GetComponent<Button>().GetComponent<Image>().sprite = _o;
		actiAlpha(1);
		_inUso = true;
		_tgm.nTurni++;
	}

}
