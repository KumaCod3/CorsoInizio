using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posINcam : MonoBehaviour
{
    public bool FPS;
    private float scostamento = 0.03f;
    Vector3 myPosition;
    Quaternion myOrient;
    public GameObject pers;

    // Start is called before the first frame update
    void Start()
    {
        if (!FPS)
        {
            scostamento = 3;
		}
        transform.rotation = pers.gameObject.transform.rotation;
        transform.eulerAngles = new Vector3(8, 0, 0);
        transform.position = pers.gameObject.transform.position - transform.forward * scostamento*2;
        transform.position += transform.up * scostamento/2;
    }
    void Update()
    {
        
    }
}
