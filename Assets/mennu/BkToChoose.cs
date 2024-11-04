using UnityEngine;

public class BkToChoose: MonoBehaviour
{
	public void OnClick()
	{
		BuildWalls.onEnd();
		UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}
}
