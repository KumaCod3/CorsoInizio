using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
