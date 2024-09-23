using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottone : MonoBehaviour
{
    public GameObject dropD;
    public int indice=0;

 public void OnClick()
    {
        indice = dropD.GetComponent<indice>().getIndex();
        PlayerPrefs.SetInt("materiale", indice);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            

    }
}
