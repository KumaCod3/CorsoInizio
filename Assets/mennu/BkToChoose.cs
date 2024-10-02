using UnityEngine;

public class BkToChoose: MonoBehaviour
{
	public void OnClick()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}
}
