using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class papier : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void imprimer() {

        Debug.Log("IMPRIMER") ;

        MeshRenderer m_MrPapier = GetComponent<MeshRenderer>(); 
        m_MrPapier.material = (Material)Resources.Load("Materials/Buzzer/BuzzerOn", typeof(Material));

    }



}
