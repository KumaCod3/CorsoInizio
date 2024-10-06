using TMPro;
using UnityEngine;

public class SparaTutti: MonoBehaviour
{
	public SchermoPuntiTiro scre;
	public TextMeshProUGUI punteggioTesto;
	public int punteggio;
	GameObject obb;
	public Camera cam;
	public GameObject colpo;

	void Start()
	{
		setPunti();
	}

	void Update()
	{
		if (scre.fine)
		{
			gameObject.GetComponent<MoveTiro>().enabled = false;
			gameObject.GetComponent<SparaTutti>().enabled = false;
		}
		if (Input.GetMouseButton(0))
		{

			RaycastHit info;
			Ray rr = cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
			Physics.Raycast(rr, out info);
			if (!Physics.Raycast(rr, out info))
			{
				if (scre._tm != true)
				{
					scre._tm = true;
				}
			}
			else
			{

				obb = info.collider.gameObject;
				Vector3 pos = info.point;
				Quaternion rotation = gameObject.transform.rotation;
				GameObject x = Instantiate(colpo, pos, rotation);

				if (obb.GetComponent<Bersaglio>() && obb.GetComponent<Bersaglio>().vivo)
				{
					if (obb.GetComponent<Bersaglio>().civ)
					{
						scre.killCiv();
					}
					else if (obb.GetComponent<Bersaglio>().enem)
					{
						scre.killEnem();
					}
					else
					{
						scre.killBos();
					}
					punteggio = punteggio + obb.GetComponent<Bersaglio>().valore;
					StartCoroutine(obb.GetComponent<Bersaglio>().muori());
					setPunti();
					obb.GetComponent<Bersaglio>().vivo = false;
				}
				else if (!obb.GetComponent<Bersaglio>() && scre._tm != true)
				{
					scre._tm = true;
				}
			}
		}

	}

	private void setPunti()
	{
		punteggioTesto.text = "" + punteggio;
		scre.poinFin = punteggio;
	}
}
