using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cle2 : MonoBehaviour

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

        
            GameObject  ChildGameObject1 = gameObject.transform.GetChild (0).gameObject;
            GameObject  ChildGameObject2 = ChildGameObject1.transform.GetChild (0).gameObject;

            BoxCollider mr_visiblePorte  = ChildGameObject2.GetComponentInChildren<BoxCollider>();
            mr_visiblePorte.enabled = false;

            MeshRenderer mr_visiblePorteMR  = ChildGameObject2.GetComponentInChildren<MeshRenderer>();
            mr_visiblePorteMR.enabled = false;


    }


}
