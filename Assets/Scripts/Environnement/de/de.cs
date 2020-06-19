using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class de : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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


        }
    }

}
