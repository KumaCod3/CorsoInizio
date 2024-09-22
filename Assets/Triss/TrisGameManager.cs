using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrisGameManager : MonoBehaviour
{
	public bool _turno = false;
	static int[][] _board = new int[3][];
	[SerializeField] public TrisButt[] _schema;
	public int _winner = 0;
	public bool _pause = false;
	public WinnerMenu _wm;
	public ScriptScelta _st;
	public TrisCamera _tc;
	public static int nTurni = 0;
	void Start()
	{
		_wm.gameObject.SetActive(true);
		_tc.gameObject.SetActive(true);
		comincia();
	}
	public void comincia()
	{

		_st.gameObject.SetActive(true);
		_wm.gameObject.SetActive(false);
		_tc.gameObject.SetActive(false);

	}
	private void Update()
	{
		if (_winner != 0 && _pause==false)
		{
			pause();
			
			_wm.gameObject.SetActive(true);
			_wm.vinci(_winner);
			_tc.vince(_winner);
			_tc.gameObject.SetActive(false);
		}
	}

	public void aggiornaSchema()
	{
		for (int x = 0; x < _board.Length; x++)
		{
			for (int y = 0; y < _board[0].Length; y++)
			{
				_board[x][y] = _schema[(x * 3) + (y)]._chi;
			}
		}
	}

	
	public void CambioTurno()
	{
		_turno = !_turno;
		nTurni++;
		aggiornaSchema();
		checkWinner();
	}

	private void checkWinner()
	{
		for (int x = 0; x < _board.Length; x++)// orizzontali
		{
			if (_board[x][0] == _board[x][1] && _board[x][0] == _board[x][2])
			{
				_winner = _board[x][0];
				return;
			}
		}
		for (int y = 0; y < _board.Length; y++)//verticali
		{
			if (_board[0][y] == _board[1][y] && _board[0][y] == _board[2][y])
			{
				_winner = _board[0][y];
				return;
			}
		}
		if (_board[0][0] == _board[1][1] && _board[0][0] == _board[2][2])
		{
			_winner = _board[0][0];
			return;
		}
		if (_board[0][2] == _board[1][1] && _board[0][2] == _board[2][0])
		{
			_winner = _board[0][2];
			return;
		}
		if (nTurni >= 9)
		{
			_winner = 100;
			return;
		}
	}
	void pause()
	{
		_pause = true;
		Time.timeScale = 0;
	}
	public void play()
	{
		_pause = false;
		Time.timeScale = 1;
	}

	public void RePlay()
	{
		for (int i = 0; i < _board.Length; i++)
		{
			_board[i] = new int[3];
		}
		nTurni = 0;
		_winner = 0;
		_wm.gameObject.SetActive(false);
		_tc.gameObject.SetActive(true);
		_st.gameObject.SetActive(false);
		cancellaSegni();
		play();
	}
	public void cancellaSegni()
	{
		foreach (TrisButt bt in _schema)
		{
			bt.resetta();
		}
	}

	public void scelgoO()
	{
		_turno = false;
		RePlay();
	}
	public void scelgoX()
	{
		_turno = true;
		RePlay();
	}
	public void Esci()
	{
		Debug.Log("esco");
		Application.Quit();
	}
}
