using UnityEngine;

public class movOggetto: MonoBehaviour
{
	public bool gonfia;
	bool up;
	int crescita = 5;
	float iniziale;
	float big;
	Vector3 delta = new Vector3(.07f, .07f, .07f);

	private void Start()
	{
		iniziale = gameObject.transform.localScale.x;
		big = iniziale + crescita;
		up = true;
	}

	private void Update()
	{
		gameObject.transform.Rotate(new Vector3(0, 2, 0));
		if (gonfia)
		{
			if (up)
			{
				gameObject.transform.localScale += delta;
				if (gameObject.transform.localScale.x >= big)
				{
					up = false;
				}
			}
			else
			{
				gameObject.transform.localScale -= delta;
				if (gameObject.transform.localScale.x <= iniziale)
				{
					up = true;
				}
			}
		}
	}
}
