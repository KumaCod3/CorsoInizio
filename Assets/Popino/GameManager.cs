using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public InputManager _iM;

	void Start()
	{
		_iM.running = KeyCode.LeftShift;

	}

	void Update()
	{
	}
}
