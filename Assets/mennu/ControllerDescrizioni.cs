using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControllerDescrizioni: MonoBehaviour
{
	string[] titoli;
	string[] descrizioni;
	int indice = 0;
	public TextMeshProUGUI tits;
	public TextMeshProUGUI des;
	public Button carica;

	void Start()
	{
		carica = gameObject.transform.GetChild(2).GetComponent<Button>();
		titoli = new string[4];
		descrizioni = new string[4];

		titoli[0] = "";
		descrizioni[0] = "";

		titoli[1] = "My Little Packman";
		descrizioni[1] = "To move you can use both arrows and WASD, each yellow ball gives 10 points and a few seconds, each red ball takes " +
			"away ten points and a life. If you get 5 yellow balls, a red cube will appear which gives 50 points and a life, but you " +
			"have to hurry!It will only stay for 10 seconds. The blue buttons in the corners take a life from you, but in return they make " +
			"the walls disappear for a few seconds! ESC and DEL will lose the game!";

		titoli[2] = "My Little DOOM";
		descrizioni[2] = "To move you can use WASD, each GOLD target gives 15 points, each PURPLE target gives 2 points, each BLUE " +
			"target takes away 20 points, and three seconds, each miss takes away 3 seconds. How many points can you score in 60 seconds ??? " +
			"Pressing ESC will make you lose the game!";

		titoli[3] = "My Little TIC TAC TOE";
		descrizioni[3] = "Just your average TIC TAC TOE. Choose who starts, and take turn to play locally.";

	}

	public void setGame(int x)
	{
		indice = x;
		tits.SetText(titoli[x]);
		des.SetText(descrizioni[x]);

		carica.GetComponent<StartGame>().indice = x;
	}
}
