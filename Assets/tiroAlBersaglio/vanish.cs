using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vanish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(via());
    }

    private IEnumerator via()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
