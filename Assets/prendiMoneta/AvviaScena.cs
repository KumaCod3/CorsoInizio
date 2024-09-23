using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvviaScena : MonoBehaviour
{
    private int materiale=2;
    public List<Material> mat;
    // Start is called before the first frame update
    void Start()
    {
        materiale = PlayerPrefs.GetInt("materiale");
        cambiaMat(materiale);
    }

	private void cambiaMat(int materiale)
	{
        gameObject.GetComponent<MeshRenderer>().material= mat[materiale];
	}

	// Update is called once per frame
	void Update()
    {
        
    }
    
}
