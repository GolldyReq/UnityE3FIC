using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("START");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


       //Le joueur récupére la cle
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        MeshRenderer mr_visible  = gameObject.GetComponent<MeshRenderer>();
        mr_visible.enabled = false;

        // rendre la porte accessible 

        GameObject porte = new GameObject();
        porte = GameObject.Find("Porte");
        if(porte != null)
        {
            Debug.Log("il y a une porte") ; 

            BoxCollider mr_visiblePorte  = porte.GetComponent<BoxCollider>();
            mr_visiblePorte.enabled = false;

            MeshRenderer mr_visiblePorteMR  = porte.GetComponent<MeshRenderer>();
            mr_visiblePorteMR.enabled = false;
        }
        else if (porte == null)
        {
            Debug.Log("il n'y a pas de porte") ; 
        }

    }


}
