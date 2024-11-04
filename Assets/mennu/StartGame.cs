using UnityEngine;

public class StartGame: MonoBehaviour
{
	public int indice = 0;
	public void OnClick()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(indice);
	}
}
