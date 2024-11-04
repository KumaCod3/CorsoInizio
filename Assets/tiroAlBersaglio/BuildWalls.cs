using System.Collections.Generic;
using UnityEngine;

public class BuildWalls: MonoBehaviour
{
	public GameObject muroX;
	public GameObject muroZ;
	public GameObject muri;
	public SchermoPuntiTiro pann;
	public GameObject civile;
	[Range(0, 20)]
	public int numCivili;
	public GameObject bersaglio;
	[Range(0, 20)]
	public int numBersagli;
	public GameObject bersaglioSuper;
	[Range(0, 5)]
	public int numSuper;
	public GameObject bersagli;

	public Texture2D cursorTexture;
	static public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

	void Start()
	{
		hotSpot.x = hotSpot.x + 50;
		hotSpot.y = hotSpot.y + 50;
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
		creaBordo();
		creaLab();
		mettiCiccia();
	}

	public static void onEnd()
	{
		Cursor.SetCursor(null, Vector2.zero, cursorMode);
	}

	void Update()
	{
		if (pann.fine)
		{
			bersagli.SetActive(false);
		}
		else if (Input.GetKeyDown(KeyCode.Escape))
		{
			pann.fine = true;
		}
	}

	private void creaBordo()
	{
		for (int i = -95; i <= 95; i = i + 10)
		{
			GameObject uno = Instantiate(muroX);
			GameObject due = Instantiate(muroX);
			GameObject tre = Instantiate(muroZ);
			GameObject quattro = Instantiate(muroZ);
			uno.transform.position = new Vector3(i, 5, 100);
			due.transform.position = new Vector3(i, 5, -100);
			tre.transform.position = new Vector3(100, 5, i);
			quattro.transform.position = new Vector3(-100, 5, i);
			uno.transform.parent = muri.transform;
			due.transform.parent = muri.transform;
			tre.transform.parent = muri.transform;
			quattro.transform.parent = muri.transform;
		}
	}
	private void creaLab()
	{
		for (int i = -85; i <= 85; i = i + 10)
		{
			for (int h = -85; h <= 85; h = h + 10)
			{
				if (((h + i) / 10) % 2 == 0)
				{
					GameObject uno = Instantiate(muroX);
					GameObject due = Instantiate(muroX);
					GameObject tre = Instantiate(muroZ);
					GameObject quattro = Instantiate(muroZ);
					uno.transform.position = new Vector3(i, 5, h + 5);
					due.transform.position = new Vector3(i, 5, h - 5);
					tre.transform.position = new Vector3(h + 5, 5, i);
					quattro.transform.position = new Vector3(h - 5, 5, i);
					uno.transform.parent = muri.transform;
					due.transform.parent = muri.transform;
					tre.transform.parent = muri.transform;
					quattro.transform.parent = muri.transform;
					uno.SetActive(false);
					due.SetActive(false);
					tre.SetActive(false);
					quattro.SetActive(false);
					List<GameObject> aa = new List<GameObject>();
					aa.Add(uno);
					aa.Add(due);
					aa.Add(tre);
					aa.Add(quattro);
					int indx = Random.Range(0, 3);
					aa[indx].SetActive(true);
					int indx2 = Random.Range(0, 3);
					aa[indx2].SetActive(true);
					foreach (GameObject b in aa)
					{
						if (!b.activeSelf)
						{
							Destroy(b);
						}
					}

				}
			}
		}

	}

	private void mettiCiccia()
	{
		for (int i = 0; i < numBersagli; i++)
		{
			GameObject bers = Instantiate(bersaglio);
			bers.GetComponent<Bersaglio>().reSpawn();
			bers.transform.parent = bersagli.transform;
		}
		for (int i = 0; i < numCivili; i++)
		{
			GameObject civ = Instantiate(civile);
			civ.GetComponent<Bersaglio>().reSpawn();
			civ.transform.parent = bersagli.transform;
		}
		for (int i = 0; i < numSuper; i++)
		{
			GameObject sup = Instantiate(bersaglioSuper);
			sup.GetComponent<Bersaglio>().reSpawn();
			sup.transform.parent = bersagli.transform;
		}
	}

}
