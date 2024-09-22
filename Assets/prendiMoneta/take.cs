using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class take : MonoBehaviour
{
    bool trig;
    GameObject mon;
    public ParticleSystem yourParticleSystem;
    public List<Material> belli;
    public Material miomatoro;
    void Start()
    {
        mon = transform.GetChild(0).gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
          if (other.gameObject.GetComponent<personaggio>())
          {
            trig = true;
          }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ggio")
        {
            trig = false;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && trig)
        {
            Debug.Log("ss" + miomatoro);
            if (mon.GetComponent<MeshRenderer>().sharedMaterial.name.Contains(miomatoro.name))
            {
                Debug.Log("ORO");
                yourParticleSystem.Play();
            }
            Destroy(mon);
           
        }
    }
}
