using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Input/InputManager")]
public class InputManager: ScriptableObject
{
	public KeyCode running;
	public KeyCode crouch;
	public KeyCode jump;
	public KeyCode shooting;
	public KeyCode reloading;

}
