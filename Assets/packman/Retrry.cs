using UnityEngine;

public class Retrry: MonoBehaviour
{
	public int scena;
	public void OnClick()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(scena);
	}
}
