using System.Collections.Generic;
using UnityEngine;

public class BuildMaxe: MonoBehaviour
{
	public GameObject muroX;
	public GameObject muroZ;
	public GameObject pareti;
	public GameObject bordo;
	public GameObject ciccia;
	public GameObject veleno;
	public GameObject cicci;
	public GameObject veno;
	private List<Vector3> ci = new List<Vector3>();

	void Start()
	{
		creaBordo();
		creaLab();
		mettiCiccia();
	}

	void Update()
	{

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
			uno.transform.parent = bordo.transform;
			due.transform.parent = bordo.transform;
			tre.transform.parent = bordo.transform;
			quattro.transform.parent = bordo.transform;
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
					uno.transform.parent = pareti.transform;
					due.transform.parent = pareti.transform;
					tre.transform.parent = pareti.transform;
					quattro.transform.parent = pareti.transform;
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
				}
			}
		}

	}

	private void mettiCiccia()
	{
		for (int i = 0; i < 20; i++)
		{
			float randomX = Random.Range(0, 19) * 10 - 95;
			float randomZ = Random.Range(0, 19) * 10 - 95;
			Vector3 pos = new Vector3(randomX, 5, randomZ);
			bool temp = false;
			foreach (Vector3 x in ci)
			{
				if (x == pos)
				{
					temp = true;
				}
			}
			if (temp)
			{
				i--;
				continue;
			}
			else
			{
				GameObject cibo = Instantiate(ciccia);
				cibo.transform.position = pos;
				cibo.transform.parent = cicci.transform;
				ci.Add(pos);
			}
		}
		for (int i = 0; i < 10; i++)
		{
			float randomX = Random.Range(0, 19) * 10 - 95;
			float randomZ = Random.Range(0, 19) * 10 - 95;
			Vector3 pos = new Vector3(randomX, 5, randomZ);
			bool temp = false;
			foreach (Vector3 x in ci)
			{
				if (x == pos)
				{
					temp = true;
				}
			}
			if (temp)
			{
				i--;
				continue;
			}
			else
			{
				GameObject vel = Instantiate(veleno);
				vel.transform.position = pos;
				vel.transform.parent = veno.transform;
				ci.Add(pos);
			}
		}
	}
}
