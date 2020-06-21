using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class de : MonoBehaviour
{
        papier monPapier ; 

    [SerializeField] GameObject m_de1;
    [SerializeField] GameObject m_de2;
    [SerializeField] GameObject m_de3;
    // Start is called before the first frame update
    void Start()
    {
      //  monPapier = papier.Instantiate ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("OnCollisionEnter");

        if (other.gameObject.CompareTag("Player"))  
        {
            Debug.Log("OnCollisionEnter with Player");
                                                         
            TextMesh m_text = GetComponentInChildren<TextMesh>();

            if ( m_text.text == "9" )
            {
                Debug.Log(" 9 ");  
                m_text.text = "0"  ;

            }
            else 
            {               
                m_text.text = (int.Parse(m_text.text) + 1).ToString() ;
            }

             if (m_de1.GetComponentInChildren<TextMesh>().text == "1"  &&     //Verifier qu'on a les bon dee //5
            m_de2.GetComponentInChildren<TextMesh>().text == "1" &&   //3
            m_de3.GetComponentInChildren<TextMesh>().text == "1") 
            {
            Debug.Log(" Bon ");    
                monPapier.imprimer();
            }
            else {
                Debug.Log(" PAs Bon "); 
            }



        }
    }

}
